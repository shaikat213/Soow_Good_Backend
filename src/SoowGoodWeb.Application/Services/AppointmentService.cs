using SoowGoodWeb.DtoModels;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoowGoodWeb.Enums;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.SslCommerz;
using AgoraIO.Media;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.SignalR;

namespace SoowGoodWeb.Services
{
    public class AppointmentService : SoowGoodWebAppService, IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IRepository<DoctorChamber> _doctorChamberRepository;
        private readonly IRepository<AgentProfile> _agentRepository;
        private readonly IRepository<DoctorScheduleDaySession> _doctorScheduleSessionRepository;
        private readonly IRepository<PatientProfile> _patientProfileRepository;
        private readonly IRepository<AgentProfile> _agentProfileRepository;
        private readonly IRepository<PaymentHistory> _paymentHistoryRepository;
        private readonly IRepository<Notification> _notificationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        //private readonly SslCommerzGatewayManager _sslCommerzGatewayManager;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;


        private readonly uint _expireTimeInSeconds = 3600;
        public AppointmentService(IRepository<Appointment> appointmentRepository,
            IRepository<DoctorChamber> doctorChamberRepository,
            IRepository<AgentProfile> agentRepository,
            IRepository<PaymentHistory> paymentHistoryRepository,
            IRepository<DoctorScheduleDaySession> doctorScheduleSessionRepository,
            IRepository<PatientProfile> patientProfileRepository,
            IRepository<AgentProfile> agentProfileRepository,
            //SslCommerzGatewayManager sslCommerzGatewayManager,
            IUnitOfWorkManager unitOfWorkManager,
            IHubContext<BroadcastHub, IHubClient> hubContext,
            IRepository<Notification> notificationRepository)
        {
            _appointmentRepository = appointmentRepository;
            //_doctorScheduleRepository = doctorScheduleRepository;
            _doctorChamberRepository = doctorChamberRepository;
            _doctorScheduleSessionRepository = doctorScheduleSessionRepository;
            _patientProfileRepository = patientProfileRepository;
            _agentProfileRepository = agentProfileRepository;
            //_sslCommerzGatewayManager = sslCommerzGatewayManager;
            _agentRepository = agentRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _hubContext = hubContext;
            _paymentHistoryRepository = paymentHistoryRepository;
            _notificationRepository = notificationRepository;
        }

        public async Task<AppointmentDto> CreateAsync(AppointmentInputDto input)
        {
            var response = new AppointmentDto();
            var notificatinInput = new NotificationInputDto();
            var notificatin = new NotificationDto();
            try
            {
                string consultancyType;
                long lastSerial;
                var chamberName = "";
                input.AppointmentDate = Convert.ToDateTime(input.AppointmentDate).AddDays(1);
                if (input.DoctorChamberId > 0)

                {
                    var appChamber = await _doctorChamberRepository.FirstOrDefaultAsync(c => c.Id == input.DoctorChamberId);
                    chamberName = appChamber.ChamberName;
                }

                var list = new List<string>();
                if (input is { DoctorScheduleId: > 0, DoctorScheduleDaySessionId: > 0 })
                {
                    var mainSession = await _doctorScheduleSessionRepository.GetAsync(s => s.Id == input.DoctorScheduleDaySessionId && s.DoctorScheduleId == input.DoctorScheduleId);
                    var stTime = Convert.ToDateTime(mainSession.StartTime);
                    var enTime = Convert.ToDateTime(mainSession.EndTime);
                    var totalHr = (enTime - stTime).TotalHours;

                    var hrMnt = totalHr * 60;
                    var slotPerPatient = hrMnt / mainSession.NoOfPatients;
                    string[]? slots = null;

                    for (var appointment = stTime; appointment < enTime; appointment = appointment.AddMinutes((double)slotPerPatient!))
                    {
                        list.Add(appointment.ToString("HH:mm"));
                        slots = list.ToArray();
                    }

                    lastSerial = await GetAppCountByScheduleIdSessionIdAsync(input.DoctorScheduleId, input.DoctorScheduleDaySessionId);


                    for (var i = lastSerial; i < mainSession.NoOfPatients;)
                    {
                        input.AppointmentTime = slots != null ? slots[i] : "";
                        break;
                    }
                    consultancyType = (input.ConsultancyType > 0 ? (ConsultancyType)input.ConsultancyType : 0).ToString();
                    input.AppointmentSerial = (lastSerial + 1).ToString();
                    //input.AppointmentCode = input.DoctorCode + input.AppointmentDate?.ToString("yyyyMMdd") + consultancyType + "SL-" + input.AppointmentSerial;
                    input.AppointmentCode = "SGAP" + input.AppointmentDate?.ToString("yyMMdd") + consultancyType.ToUpper() + "SL00" + input.AppointmentSerial;
                }
                else
                {
                    input.ConsultancyType = ConsultancyType.Instant;
                    input.AppointmentDate = DateTime.Today;
                    input.AppointmentTime = DateTime.Now.ToString("HH:mm");
                    input.AppointmentType = AppointmentType.New;
                    lastSerial = await GetAppCountByRealTimeConsultancyAsync(input.AppointmentDate);
                    consultancyType = ConsultancyType.Instant.ToString();
                    input.AppointmentSerial = (lastSerial + 1).ToString();
                    //input.AppointmentCode = input.DoctorCode + input.AppointmentDate?.ToString("yyyyMMdd") + consultancyType + "SL-" + input.AppointmentSerial;
                    input.AppointmentCode = "SGAP" + input.AppointmentDate?.ToString("yyMMdd") + consultancyType.ToUpper() + "SL-" + input.AppointmentSerial;
                }

                var newEntity = ObjectMapper.Map<AppointmentInputDto, Appointment>(input);

                var doctorChamber = await _appointmentRepository.InsertAsync(newEntity);

                response = ObjectMapper.Map<Appointment, AppointmentDto>(doctorChamber);

                response.AppointmentTypeName = response.AppointmentType.ToString();
                response.ConsultancyTypeName = response.ConsultancyType.ToString();
                response.DoctorChamberName = !string.IsNullOrEmpty(chamberName) ? chamberName.ToString() : "SoowGood Online";

            }
            catch (Exception ex)
            {
                return response;
            }

            return response;//ObjectMapper.Map<Appointment, AppointmentDto>(doctorChamber);
        }

        public async Task<AppointmentDto> UpdateAsync(AppointmentInputDto input)
        {
            var updateItem = ObjectMapper.Map<AppointmentInputDto, Appointment>(input);

            var item = await _appointmentRepository.UpdateAsync(updateItem);

            return ObjectMapper.Map<Appointment, AppointmentDto>(item);
        }

        public async Task<AppointmentDto?> GetAsync(int id)
        {
            var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
            var schedule = item.FirstOrDefault(x => x.Id == id);
            var result = schedule != null ? ObjectMapper.Map<Appointment, AppointmentDto>(schedule) : null;

            return result;
        }

        public async Task<List<AppointmentDto>> GetListAsync()
        {
            var appointments = await _appointmentRepository.GetListAsync();
            return ObjectMapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>> GetAppointmentListByDoctorIdAsync(long doctorId)
        {
            var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
            var appointments = item.Where(d => d.DoctorProfileId == doctorId && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed)).ToList();
            return ObjectMapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>?> GetAppointmentListForDoctorWithSearchFilterAsync(long doctorId, DataFilterModel? dataFilter, FilterModel filterModel)
        {
            var provider = CultureInfo.InvariantCulture;

            try
            {
                var fDate1 = Convert.ToDateTime(dataFilter.fromDate).Date;
                var tdate1 = DateTime.Now;
                if (dataFilter?.toDate is null or "Invalid Date")
                {
                    dataFilter.toDate = dataFilter.fromDate;
                    tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;

                }
                else
                {
                    tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;
                }
                var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
                var appointments = item.Where(d => d.DoctorProfileId == doctorId && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed)).ToList();// && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed)).ToList();

                if (!string.IsNullOrEmpty(dataFilter?.name))
                {
                    appointments = appointments.Where(p => p.PatientName != null && p.PatientName.ToLower().Contains(dataFilter.name.ToLower().Trim())).ToList();
                }
                if (dataFilter?.consultancyType > 0)
                {
                    appointments = appointments.Where(p => p.ConsultancyType == dataFilter.consultancyType).ToList();
                }
                if (dataFilter?.appointmentStatus > 0)
                {
                    appointments = appointments.Where(p => p.AppointmentStatus == dataFilter.appointmentStatus).ToList();
                }
                if (!string.IsNullOrEmpty(dataFilter?.fromDate) && !string.IsNullOrEmpty(dataFilter.toDate))
                {
                    appointments = appointments.Where(p => p?.AppointmentDate.Value.Date >= fDate1
                            && p?.AppointmentDate.Value.Date <= tdate1).ToList();
                }

                return ObjectMapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<int> GetAppointmentCountForDoctorWithSearchFilterAsync(long doctorId, DataFilterModel? dataFilter)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                var fDate1 = Convert.ToDateTime(dataFilter.fromDate).Date;
                var tdate1 = DateTime.Now;
                if (dataFilter?.toDate is null or "Invalid Date")
                {
                    if (dataFilter != null)
                    {
                        dataFilter.toDate = dataFilter.fromDate;
                        tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;
                    }
                }
                var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
                var appointments = item.Where(d => d.DoctorProfileId == doctorId && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed)).ToList();// && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed)).ToList();

                if (!string.IsNullOrEmpty(dataFilter?.name))
                {
                    appointments = appointments.Where(p => p.PatientName != null && p.PatientName.ToLower().Contains(dataFilter.name.ToLower().Trim())).ToList();
                }
                if (dataFilter?.consultancyType > 0)
                {
                    appointments = appointments.Where(p => p.ConsultancyType == dataFilter.consultancyType).ToList();
                }
                if (!string.IsNullOrEmpty(dataFilter?.fromDate) && !string.IsNullOrEmpty(dataFilter.toDate))
                {
                    appointments = appointments.Where(p => p?.AppointmentDate.Value.Date >= fDate1
                            && p?.AppointmentDate.Value.Date <= tdate1).ToList();
                }
                return appointments.Count();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public async Task<List<AppointmentDto>> GetAppointmentListByPatientIdAsync(long patientId, string role)
        {
            var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
            var appointments = item.Where(d => d.AppointmentCreatorId == patientId && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed) && d.AppointmentCreatorRole == role).ToList();
            return ObjectMapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>> GetAppointmentListForPatientWithSearchFilterAsync(long patientId, string role, DataFilterModel? dataFilter, FilterModel filterModel)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                var fDate1 = Convert.ToDateTime(dataFilter.fromDate).Date;
                var tdate1 = DateTime.Now;
                if (dataFilter?.toDate is null or "Invalid Date")
                {
                    dataFilter.toDate = dataFilter.fromDate;
                    tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;
                }
                else
                {
                    tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;
                }
                var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
                var appointments = item.Where(d => d.AppointmentCreatorId == patientId && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed) && d.AppointmentCreatorRole == role).ToList();// && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed)).ToList();

                if (!string.IsNullOrEmpty(dataFilter?.name))
                {
                    appointments = appointments.Where(p => p.PatientName != null && p.PatientName.ToLower().Contains(dataFilter.name.ToLower().Trim())).ToList();
                }
                if (dataFilter?.consultancyType > 0)
                {
                    appointments = appointments.Where(p => p.ConsultancyType == dataFilter.consultancyType).ToList();
                }
                if (!string.IsNullOrEmpty(dataFilter?.fromDate) && !string.IsNullOrEmpty(dataFilter.toDate))
                {
                    appointments = appointments.Where(p => p?.AppointmentDate.Value.Date >= fDate1
                            && p?.AppointmentDate.Value.Date <= tdate1).ToList();
                }

                //appointments = appointments.Skip(filterModel.Offset)
                //                   .Take(filterModel.Limit).ToList();

                return ObjectMapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<int> GetAppointmentCountForPatientWithSearchFilterAsync(long patientId, string role, DataFilterModel? dataFilter)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                var fDate1 = Convert.ToDateTime(dataFilter.fromDate).Date;
                var tdate1 = DateTime.Now;
                if (dataFilter?.toDate is null or "Invalid Date")
                {
                    if (dataFilter != null)
                    {
                        dataFilter.toDate = dataFilter.fromDate;
                        tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;
                    }
                }
                var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
                var appointments = item.Where(d => d.AppointmentCreatorId == patientId && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed) && d.AppointmentCreatorRole == role).ToList();// && (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed)).ToList();

                if (!string.IsNullOrEmpty(dataFilter?.name))
                {
                    appointments = appointments.Where(p => p.PatientName != null && p.PatientName.ToLower().Contains(dataFilter.name.ToLower().Trim())).ToList();
                }
                if (dataFilter?.consultancyType > 0)
                {
                    appointments = appointments.Where(p => p.ConsultancyType == dataFilter.consultancyType).ToList();
                }
                if (!string.IsNullOrEmpty(dataFilter?.fromDate) && !string.IsNullOrEmpty(dataFilter.toDate))
                {
                    appointments = appointments.Where(p => p?.AppointmentDate.Value.Date >= fDate1
                            && p?.AppointmentDate.Value.Date <= tdate1).ToList();
                }

                return appointments.Count;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public async Task<List<AppointmentDto>?> GetListAppointmentListByAdminAsync()
        {
            List<AppointmentDto>? result = null;
            DoctorScheduleDaySession? weekDayName = null;
            var allAppoinments = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule, c => c.DoctorSchedule.DoctorChamber);
            //var allAppoinment = allAppoinments.OrderByDescending(d => d.AppointmentDate).ToList();
            var agentDetails = await _agentProfileRepository.WithDetailsAsync(a => a.AgentMaster, s => s.AgentSupervisor);
            //var  = await _appointmentRepository.GetListAsync();
            if (!allAppoinments.Any())
            {
                return result;
            }

            result = new List<AppointmentDto>();
            try
            {

                foreach (var item in allAppoinments)
                {
                    var patientDetails = await _patientProfileRepository.GetAsync(p => p.Id == item.PatientProfileId);

                    //if(item.AppointmentCreatorRole=="agent")
                    var agent = item.AppointmentCreatorRole == "agent" ? agentDetails.Where(a => a.Id == item.AppointmentCreatorId).FirstOrDefault() : null;
                    var sDsession = await _doctorScheduleSessionRepository.GetListAsync(s => s.IsDeleted == false);
                    if (item.DoctorScheduleDaySessionId > 0)
                    {
                        weekDayName = sDsession.FirstOrDefault(p => p.Id == item.DoctorScheduleDaySessionId);
                    }
                    result.Add(new AppointmentDto()
                    {
                        Id = item.Id,
                        PatientName = item.PatientName,
                        AppointmentDate = Convert.ToDateTime(item.AppointmentDate).Date,
                        AppointmentTime = item.AppointmentTime,
                        AppointmentSerial = item.AppointmentSerial,
                        AppointmentType = item.AppointmentType,
                        AppointmentTypeName = item.AppointmentType > 0 ? ((AppointmentType)item.AppointmentType).ToString() : "n/a",
                        DoctorName = item.DoctorName,
                        DoctorScheduleId = item.DoctorScheduleId,
                        DoctorScheduleName = item.DoctorScheduleId > 0 ? item.DoctorSchedule?.ScheduleName : "n/a",
                        AppointmentCode = item.AppointmentCode,
                        AppointmentStatus = item.AppointmentStatus,
                        DoctorCode = item.DoctorCode,
                        PatientCode = item.PatientCode,
                        PatientMobileNo = patientDetails.PatientMobileNo,
                        PatientEmail = patientDetails.PatientEmail,
                        AppointmentStatusName = item.AppointmentStatus > 0 ? ((AppointmentStatus)item.AppointmentStatus).ToString() : "n/a",
                        AppointmentPaymentStatus = item.AppointmentPaymentStatus,
                        AppointmentPaymentStatusName = item.AppointmentPaymentStatus > 0 ? ((AppointmentPaymentStatus)item.AppointmentPaymentStatus).ToString() : "n/a",
                        ConsultancyType = item.ConsultancyType,
                        ConsultancyTypeName = item.ConsultancyType > 0 ? ((ConsultancyType)item.ConsultancyType).ToString() : "n/a",
                        DoctorChamberId = item.DoctorChamberId,
                        DoctorChamberName = item.DoctorChamberId > 0 ? item.DoctorSchedule?.DoctorChamber?.ChamberName : "n/a",
                        DoctorFee = item.DoctorFee,
                        PatientLocation = patientDetails?.City?.ToString(),
                        DoctorScheduleDaySessionId = item.DoctorScheduleDaySessionId,
                        ScheduleDayofWeek = weekDayName?.ScheduleDayofWeek?.ToString(),
                        CancelledByRole = item.CancelledByRole,
                        PaymentTransactionId = item.PaymentTransactionId,
                        AppointmentCreatorRole = item.AppointmentCreatorRole,
                        BoothName = item.AppointmentCreatorRole == "agent" ? agent?.Address : "N/A",
                        AgentMasterName = item.AppointmentCreatorRole == "agent" ? agent?.AgentMaster?.AgentMasterOrgName : "N/A",
                        AgentSupervisorName = item.AppointmentCreatorRole == "agent" ? agent?.AgentSupervisor?.AgentSupervisorOrgName : "N/A",
                    });
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            var list = result.OrderBy(item => item.AppointmentSerial)
                .GroupBy(item => item.AppointmentDate)
                .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            return result;
        }

        public async Task<List<AppointmentDto>?> GetListAppointmentListByAgentMasterAsync(long agentMasterId)
        {
            List<AppointmentDto>? result = null;
            DoctorScheduleDaySession? weekDayName = null;
            var allAppoinment = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule, c => c.DoctorSchedule.DoctorChamber);
            var appointments = allAppoinment.Where(c => c.AppointmentCreatorRole == "agent").ToList();
            var agentDetails = await _agentProfileRepository.WithDetailsAsync(a => a.AgentMaster, s => s.AgentSupervisor);
            var agentsByMasters = agentDetails.Where(a => a.AgentMasterId == agentMasterId).ToList();

            var itemAppointments = (from app in appointments join agents in agentsByMasters on app.AppointmentCreatorId equals agents.Id select app).ToList();

            //allAppoinment.Where(ap=>ap.AppointmentCreatorId == agentMasterId);
            //var  = await _appointmentRepository.GetListAsync();
            if (!itemAppointments.Any())
            {
                return result;
            }

            result = new List<AppointmentDto>();
            try
            {

                foreach (var item in itemAppointments)
                {
                    var patientDetails = await _patientProfileRepository.GetAsync(p => p.Id == item.PatientProfileId);

                    //if(item.AppointmentCreatorRole=="agent")
                    var agent = item.AppointmentCreatorRole == "agent" ? agentsByMasters.Where(a => a.Id == item.AppointmentCreatorId).FirstOrDefault() : null;
                    var sDsession = await _doctorScheduleSessionRepository.GetListAsync(s => s.IsDeleted == false);
                    if (item.DoctorScheduleDaySessionId > 0)
                    {
                        weekDayName = sDsession.FirstOrDefault(p => p.Id == item.DoctorScheduleDaySessionId);
                    }
                    result.Add(new AppointmentDto()
                    {
                        Id = item.Id,
                        PatientName = item.PatientName,
                        AppointmentDate = Convert.ToDateTime(item.AppointmentDate).Date,
                        AppointmentTime = item.AppointmentTime,
                        AppointmentSerial = item.AppointmentSerial,
                        AppointmentType = item.AppointmentType,
                        AppointmentTypeName = item.AppointmentType > 0 ? ((AppointmentType)item.AppointmentType).ToString() : "n/a",
                        DoctorName = item.DoctorName,
                        DoctorScheduleId = item.DoctorScheduleId,
                        DoctorScheduleName = item.DoctorScheduleId > 0 ? item.DoctorSchedule?.ScheduleName : "n/a",
                        AppointmentCode = item.AppointmentCode,
                        AppointmentStatus = item.AppointmentStatus,
                        DoctorCode = item.DoctorCode,
                        PatientCode = item.PatientCode,
                        PatientMobileNo = patientDetails.PatientMobileNo,
                        PatientEmail = patientDetails.PatientEmail,
                        AppointmentStatusName = item.AppointmentStatus > 0 ? ((AppointmentStatus)item.AppointmentStatus).ToString() : "n/a",
                        AppointmentPaymentStatus = item.AppointmentPaymentStatus,
                        AppointmentPaymentStatusName = item.AppointmentPaymentStatus > 0 ? ((AppointmentPaymentStatus)item.AppointmentPaymentStatus).ToString() : "n/a",
                        ConsultancyType = item.ConsultancyType,
                        ConsultancyTypeName = item.ConsultancyType > 0 ? ((ConsultancyType)item.ConsultancyType).ToString() : "n/a",
                        DoctorChamberId = item.DoctorChamberId,
                        DoctorChamberName = item.DoctorChamberId > 0 ? item.DoctorSchedule?.DoctorChamber?.ChamberName : "n/a",
                        DoctorFee = item.DoctorFee,
                        PatientLocation = patientDetails?.City?.ToString(),
                        DoctorScheduleDaySessionId = item.DoctorScheduleDaySessionId,
                        ScheduleDayofWeek = weekDayName?.ScheduleDayofWeek?.ToString(),
                        CancelledByRole = item.CancelledByRole,
                        PaymentTransactionId = item.PaymentTransactionId,
                        AppointmentCreatorRole = item.AppointmentCreatorRole,
                        BoothName = item.AppointmentCreatorRole == "agent" ? agent?.Address : "N/A",
                        AgentMasterName = item.AppointmentCreatorRole == "agent" ? agent?.AgentMaster?.AgentMasterOrgName : "N/A",
                        AgentSupervisorName = item.AppointmentCreatorRole == "agent" ? agent?.AgentSupervisor?.AgentSupervisorOrgName : "N/A",
                    });
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            var list = result.OrderBy(item => item.AppointmentSerial)
                .GroupBy(item => item.AppointmentDate)
                .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            return result;
        }

        public async Task<List<AppointmentDto>?> GetListAppointmentListByAgentSupervisorAsync(long supervisorId)
        {
            List<AppointmentDto>? result = null;
            DoctorScheduleDaySession? weekDayName = null;
            var allAppoinment = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule, c => c.DoctorSchedule.DoctorChamber);
            var appointments = allAppoinment.Where(c => c.AppointmentCreatorRole == "agent").ToList();
            var agentDetails = await _agentProfileRepository.WithDetailsAsync(a => a.AgentMaster, s => s.AgentSupervisor);
            var agentsBySupervisors = agentDetails.Where(a => a.AgentMasterId == supervisorId).ToList();

            var itemAppointments = (from app in appointments join agents in agentsBySupervisors on app.AppointmentCreatorId equals agents.Id select app).ToList();

            //allAppoinment.Where(ap=>ap.AppointmentCreatorId == agentMasterId);
            //var  = await _appointmentRepository.GetListAsync();
            if (!itemAppointments.Any())
            {
                return result;
            }

            result = new List<AppointmentDto>();
            try
            {

                foreach (var item in itemAppointments)
                {
                    var patientDetails = await _patientProfileRepository.GetAsync(p => p.Id == item.PatientProfileId);

                    //if(item.AppointmentCreatorRole=="agent")
                    var agent = item.AppointmentCreatorRole == "agent" ? agentsBySupervisors.Where(a => a.Id == item.AppointmentCreatorId).FirstOrDefault() : null;
                    var sDsession = await _doctorScheduleSessionRepository.GetListAsync(s => s.IsDeleted == false);
                    if (item.DoctorScheduleDaySessionId > 0)
                    {
                        weekDayName = sDsession.FirstOrDefault(p => p.Id == item.DoctorScheduleDaySessionId);
                    }
                    result.Add(new AppointmentDto()
                    {
                        Id = item.Id,
                        PatientName = item.PatientName,
                        AppointmentDate = Convert.ToDateTime(item.AppointmentDate).Date,
                        AppointmentTime = item.AppointmentTime,
                        AppointmentSerial = item.AppointmentSerial,
                        AppointmentType = item.AppointmentType,
                        AppointmentTypeName = item.AppointmentType > 0 ? ((AppointmentType)item.AppointmentType).ToString() : "n/a",
                        DoctorName = item.DoctorName,
                        DoctorScheduleId = item.DoctorScheduleId,
                        DoctorScheduleName = item.DoctorScheduleId > 0 ? item.DoctorSchedule?.ScheduleName : "n/a",
                        AppointmentCode = item.AppointmentCode,
                        AppointmentStatus = item.AppointmentStatus,
                        DoctorCode = item.DoctorCode,
                        PatientCode = item.PatientCode,
                        PatientMobileNo = patientDetails.PatientMobileNo,
                        PatientEmail = patientDetails.PatientEmail,
                        AppointmentStatusName = item.AppointmentStatus > 0 ? ((AppointmentStatus)item.AppointmentStatus).ToString() : "n/a",
                        AppointmentPaymentStatus = item.AppointmentPaymentStatus,
                        AppointmentPaymentStatusName = item.AppointmentPaymentStatus > 0 ? ((AppointmentPaymentStatus)item.AppointmentPaymentStatus).ToString() : "n/a",
                        ConsultancyType = item.ConsultancyType,
                        ConsultancyTypeName = item.ConsultancyType > 0 ? ((ConsultancyType)item.ConsultancyType).ToString() : "n/a",
                        DoctorChamberId = item.DoctorChamberId,
                        DoctorChamberName = item.DoctorChamberId > 0 ? item.DoctorSchedule?.DoctorChamber?.ChamberName : "n/a",
                        DoctorFee = item.DoctorFee,
                        PatientLocation = patientDetails?.City?.ToString(),
                        DoctorScheduleDaySessionId = item.DoctorScheduleDaySessionId,
                        ScheduleDayofWeek = weekDayName?.ScheduleDayofWeek?.ToString(),
                        CancelledByRole = item.CancelledByRole,
                        PaymentTransactionId = item.PaymentTransactionId,
                        AppointmentCreatorRole = item.AppointmentCreatorRole,
                        BoothName = item.AppointmentCreatorRole == "agent" ? agent?.Address : "N/A",
                        AgentMasterName = item.AppointmentCreatorRole == "agent" ? agent?.AgentMaster?.AgentMasterOrgName : "N/A",
                        AgentSupervisorName = item.AppointmentCreatorRole == "agent" ? agent?.AgentSupervisor?.AgentSupervisorOrgName : "N/A",
                    });
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            var list = result.OrderBy(item => item.AppointmentSerial)
                .GroupBy(item => item.AppointmentDate)
                .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            return result;
        }

        public async Task<int> GetAppCountByScheduleIdSessionIdAsync(long? scheduleId, long? sessionId)
        {
            var appointments = await _appointmentRepository.GetListAsync(a => a.DoctorScheduleId == scheduleId && a.DoctorScheduleDaySessionId == sessionId);
            var appCount = appointments.Count();
            return appCount;
        }

        public async Task<int> GetLeftBookingCount(long sessionId, long scheduleId)
        {
            int resultNp = 0;
            var numberOfPatintforScheduleSession = await _doctorScheduleSessionRepository.GetAsync(s => s.Id == sessionId && s.DoctorScheduleId == scheduleId);
            int noOfPatients = (int)numberOfPatintforScheduleSession.NoOfPatients;

            int appCounts = await GetAppCountByScheduleIdSessionIdAsync(scheduleId, sessionId);
            if (noOfPatients == appCounts)
            {
                resultNp = 0;
            }
            else if (noOfPatients > appCounts)
            {
                resultNp = (noOfPatients - appCounts);
            }
            else
            {
                resultNp = noOfPatients;
            }

            return resultNp;//noOfPatients == appCounts? 0: (int)resultNp;
        }

        public async Task<List<AppointmentDto>> GetPatientListByDoctorIdAsync(long doctorId)
        {
            var restultPatientList = new List<AppointmentDto>();
            try
            {
                var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
                //var appointments = await item.Where(d=> d.DoctorProfileId == doctorId && d.AppointmentStatus == AppointmentStatus.Confirmed).ToList();
                var appointments = item.Where(d => d.DoctorProfileId == doctorId);// && d.AppointmentStatus == AppointmentStatus.Confirmed).ToList();
                var patientIds = (from app in appointments
                                  select app.PatientProfileId).Distinct();
                foreach (var appointment in patientIds)
                {
                    var patient = await _patientProfileRepository.GetAsync(p => p.Id == appointment);
                    restultPatientList.Add(new AppointmentDto()
                    {
                        DoctorProfileId = doctorId,
                        PatientProfileId = patient.Id,
                        PatientCode = patient.PatientCode,
                        PatientName = patient.PatientName,
                        PatientMobileNo = patient.PatientMobileNo,
                        PatientEmail = patient.PatientEmail,
                        PatientLocation = patient.City
                    });
                }
                return restultPatientList;//ObjectMapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
            }
            catch (Exception ex)
            {
                return restultPatientList;
            }

        }

        public async Task<int> GetAppCountByRealTimeConsultancyAsync(DateTime? aptDate)
        {
            var appointments = await _appointmentRepository.GetListAsync(a => a.AppointmentDate == aptDate && a.ConsultancyType == ConsultancyType.Instant);
            var appCount = appointments.Count();
            return appCount;
        }

        public async Task<List<AppointmentDto>> GetSearchedPatientListByDoctorIdAsync(long doctorId, string name)
        {
            var restultPatientList = new List<AppointmentDto>();
            try
            {
                var item = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
                //var appointments = await item.Where(d=> d.DoctorProfileId == doctorId && d.AppointmentStatus == AppointmentStatus.Confirmed).ToList();
                var appointments = item.Where(d => d.DoctorProfileId == doctorId);// && d.AppointmentStatus == AppointmentStatus.Confirmed).ToList();
                var patientIds = (from app in appointments
                                  select app.PatientProfileId).Distinct();
                foreach (var appointment in patientIds)
                {
                    var patient = await _patientProfileRepository.GetAsync(p => p.Id == appointment);
                    restultPatientList.Add(new AppointmentDto()
                    {
                        DoctorProfileId = doctorId,
                        PatientProfileId = patient.Id,
                        PatientCode = patient.PatientCode,
                        PatientName = patient.PatientName,
                        PatientMobileNo = patient.PatientMobileNo,
                        PatientEmail = patient.PatientEmail,
                        PatientLocation = patient.City
                    });
                }

                if (!string.IsNullOrEmpty(name))
                {
                    restultPatientList = restultPatientList.Where(p => p.PatientName.Contains(name)).ToList();
                }

                return restultPatientList;//ObjectMapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
            }
            catch (Exception ex)
            {
                return restultPatientList;
            }

        }

        public async Task<List<AppointmentDto>?> GetListAppointmentListByAdminWithFilterAsync(long? userId, string? role, DataFilterModel? dataFilter)
        {
            List<AppointmentDto>? result = null;
            List<Appointment>? appointments = null;
            List<Appointment>? itemAppointments = null;
            DoctorScheduleDaySession? weekDayName = null;

            var fDate1 = Convert.ToDateTime(dataFilter.fromDate).Date;
            var tdate1 = DateTime.Now;
            if (dataFilter?.toDate is null or "Invalid Date")
            {
                dataFilter.toDate = dataFilter.fromDate;
                tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;

            }
            else
            {
                tdate1 = Convert.ToDateTime(dataFilter.toDate).Date;
            }
            var agentDetails = await _agentProfileRepository.WithDetailsAsync(a => a.AgentMaster, s => s.AgentSupervisor);
            var allAppoinment = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule, c => c.DoctorSchedule.DoctorChamber);
            if (!string.IsNullOrEmpty(role) && role != "sgadmin")
            {
                appointments = allAppoinment.Where(c => c.AppointmentCreatorRole == "agent").ToList();

                var agentsByMasterSupervisors = agentDetails.Where(a => role == "masteragent" ? a.AgentMasterId == userId : a.AgentSupervisorId == userId).ToList();

                itemAppointments = (from app in appointments join agents in agentsByMasterSupervisors on app.AppointmentCreatorId equals agents.Id select app).ToList();
            }
            else
            {
                itemAppointments = allAppoinment.Where(a => a.AppointmentStatus > 0).ToList();//allAppoinment.Where(d => (d.AppointmentStatus == AppointmentStatus.Confirmed || d.AppointmentStatus == AppointmentStatus.Completed || d.AppointmentStatus == AppointmentStatus.Pending || d.AppointmentStatus == AppointmentStatus.Cancelled || d.AppointmentStatus == AppointmentStatus.InProgress || d.AppointmentStatus == AppointmentStatus.Failed)).ToList();
            }
            if (!itemAppointments.Any())
            {
                return result;
            }
            //if (!string.IsNullOrEmpty(dataFilter?.name))
            //{
            //    itemAppointments = itemAppointments.Where(p => ((!string.IsNullOrEmpty(p.PatientName)) && (!string.IsNullOrEmpty(p.DoctorName))) && (p.PatientName.ToLower().Contains(dataFilter.name.ToLower().Trim()) || p.DoctorName.ToLower().Contains(dataFilter.name.ToLower().Trim()))).ToList();
            //}
            //if (dataFilter?.consultancyType > 0)
            //{
            //    itemAppointments = itemAppointments.Where(p => p.ConsultancyType == dataFilter.consultancyType).ToList();
            //}
            //if (dataFilter?.appointmentStatus > 0)
            //{
            //    itemAppointments = itemAppointments.Where(p => p.AppointmentStatus == dataFilter.appointmentStatus).ToList();
            //}
            //if (!string.IsNullOrEmpty(dataFilter?.fromDate) && !string.IsNullOrEmpty(dataFilter.toDate))
            //{
            //    itemAppointments = itemAppointments.Where(p => p?.AppointmentDate.Value.Date >= fDate1
            //            && p?.AppointmentDate.Value.Date <= tdate1).ToList();
            //}

            result = new List<AppointmentDto>();
            try
            {

                foreach (var item in itemAppointments)
                {
                    var patientDetails = await _patientProfileRepository.GetAsync(p => p.Id == item.PatientProfileId);

                    //if(item.AppointmentCreatorRole=="agent")
                    var agent = item.AppointmentCreatorRole == "agent" ? agentDetails.Where(a => a.Id == item.AppointmentCreatorId).FirstOrDefault() : null;
                    var sDsession = await _doctorScheduleSessionRepository.GetListAsync(s => s.IsDeleted == false);
                    if (item.DoctorScheduleDaySessionId > 0)
                    {
                        weekDayName = sDsession.FirstOrDefault(p => p.Id == item.DoctorScheduleDaySessionId);
                    }
                    result.Add(new AppointmentDto()
                    {
                        Id = item.Id,
                        PatientName = item.PatientName,
                        AppointmentDate = Convert.ToDateTime(item.AppointmentDate).Date,
                        AppointmentTime = item.AppointmentTime,
                        AppointmentSerial = item.AppointmentSerial,
                        AppointmentType = item.AppointmentType,
                        AppointmentTypeName = item.AppointmentType > 0 ? ((AppointmentType)item.AppointmentType).ToString() : "n/a",
                        DoctorName = item.DoctorName,
                        DoctorScheduleId = item.DoctorScheduleId,
                        DoctorScheduleName = item.DoctorScheduleId > 0 ? item.DoctorSchedule?.ScheduleName : "n/a",
                        AppointmentCode = item.AppointmentCode,
                        AppointmentStatus = item.AppointmentStatus,
                        DoctorCode = item.DoctorCode,
                        PatientCode = item.PatientCode,
                        PatientMobileNo = patientDetails.PatientMobileNo,
                        PatientEmail = patientDetails.PatientEmail,
                        AppointmentStatusName = item.AppointmentStatus > 0 ? ((AppointmentStatus)item.AppointmentStatus).ToString() : "n/a",
                        AppointmentPaymentStatus = item.AppointmentPaymentStatus,
                        AppointmentPaymentStatusName = item.AppointmentPaymentStatus > 0 ? ((AppointmentPaymentStatus)item.AppointmentPaymentStatus).ToString() : "n/a",
                        ConsultancyType = item.ConsultancyType,
                        ConsultancyTypeName = item.ConsultancyType > 0 ? ((ConsultancyType)item.ConsultancyType).ToString() : "n/a",
                        DoctorChamberId = item.DoctorChamberId,
                        DoctorChamberName = item.DoctorChamberId > 0 ? item.DoctorSchedule?.DoctorChamber?.ChamberName : "n/a",
                        DoctorFee = item.DoctorFee,
                        PatientLocation = patientDetails?.City?.ToString(),
                        DoctorScheduleDaySessionId = item.DoctorScheduleDaySessionId,
                        ScheduleDayofWeek = weekDayName?.ScheduleDayofWeek?.ToString(),
                        CancelledByRole = item.CancelledByRole,
                        PaymentTransactionId = item.PaymentTransactionId,
                        AppointmentCreatorRole = item.AppointmentCreatorRole,
                        BoothName = item.AppointmentCreatorRole == "agent" ? agent?.Address : "N/A",
                        AgentMasterName = item.AppointmentCreatorRole == "agent" ? agent?.AgentMaster?.AgentMasterOrgName : "N/A",
                        AgentSupervisorName = item.AppointmentCreatorRole == "agent" ? agent?.AgentSupervisor?.AgentSupervisorOrgName : "N/A",
                    });
                }
            }
            catch (Exception ex)
            {
                // ignored
            }



            if (!string.IsNullOrEmpty(dataFilter?.name))
            {
                result = result.Where(p => ((!string.IsNullOrEmpty(p.PatientName)) && (!string.IsNullOrEmpty(p.DoctorName))) && (p.PatientName.ToLower().Contains(dataFilter.name.ToLower().Trim()) || p.DoctorName.ToLower().Contains(dataFilter.name.ToLower().Trim()))).ToList();
            }
            if (dataFilter?.consultancyType > 0)
            {
                result = result.Where(p => p.ConsultancyType == dataFilter.consultancyType).ToList();
            }
            if (dataFilter?.appointmentStatus > 0)
            {
                result = result.Where(p => p.AppointmentStatus == dataFilter.appointmentStatus).ToList();
            }
            if (!string.IsNullOrEmpty(dataFilter?.fromDate) && !string.IsNullOrEmpty(dataFilter.toDate))
            {
                result = result.Where(p => p?.AppointmentDate >= fDate1
                        && p?.AppointmentDate <= tdate1).ToList();
            }


            result = result.OrderByDescending(a => a.AppointmentDate).ToList();
            var list = result.OrderBy(item => item.AppointmentSerial)
                .GroupBy(item => item.AppointmentDate)
                .OrderBy(g => g.Key).Select(g => new { g }).ToList();


            return result;
        }

        public async Task<List<SessionWeekDayTimeSlotPatientCountDto>> GetListOfSessionsWithWeekDayTimeSlotPatientCountAsync(long secheduleId, DateTime date)
        {
            var result = new List<SessionWeekDayTimeSlotPatientCountDto>();
            var weekDay = date.DayOfWeek.ToString();
            var sdSessions = await _doctorScheduleSessionRepository.WithDetailsAsync(s => s.DoctorSchedule);
            var sessions = sdSessions.Where(ds => ds.DoctorScheduleId == secheduleId && ds.ScheduleDayofWeek == weekDay).ToList();

            if (sessions.Any())
            {
                foreach (var session in sessions)
                {
                    var appointments = await _appointmentRepository.GetListAsync(a => a.AppointmentDate == date && a.DoctorScheduleDaySessionId == session.Id);
                    result.Add(new SessionWeekDayTimeSlotPatientCountDto
                    {
                        ScheduleId = session.DoctorScheduleId,
                        SessionId = session.Id,
                        WeekDay = session.ScheduleDayofWeek,
                        StartTime = session.StartTime,
                        EndTime = session.EndTime,
                        PatientCount = session.NoOfPatients - appointments.Count,
                    });

                }
            }

            return result;
        }

        public async Task<ResponseDto> CancellAppointmentAsync(long appId, long cancelByid, string cancelByRole)
        {
            var response = new ResponseDto();
            try
            {
                var itemAppointment = await _appointmentRepository.GetAsync(a => a.Id == appId);//.FindAsync(input.Id);
                itemAppointment.AppointmentStatus = AppointmentStatus.Cancelled;
                itemAppointment.CancelledByEntityId = cancelByid;
                itemAppointment.CancelledByRole = cancelByRole;



                var item = await _appointmentRepository.UpdateAsync(itemAppointment);
                //await _unitOfWorkManager.Current.SaveChangesAsync();
                var result = ObjectMapper.Map<Appointment, AppointmentDto>(item);
                if (result != null)
                {
                    response.Id = result.Id;
                    response.Value = "";
                    response.Success = true;
                    response.Message = "Consultation complete";
                }
                return response;//ObjectMapper.Map<Appointment, AppointmentDto>(item);
            }
            catch (Exception ex)
            {
                return null;
            }
            return response;
        }
        public async Task<ResponseDto> UpdateCallConsultationAppointmentAsync(string appCode)
        {
            var response = new ResponseDto();
            try
            {
                var itemAppointment = await _appointmentRepository.GetAsync(a => a.AppointmentCode == appCode);//.FindAsync(input.Id);
                itemAppointment.AppointmentStatus = AppointmentStatus.Completed;
                itemAppointment.IsCousltationComplete = true;



                var item = await _appointmentRepository.UpdateAsync(itemAppointment);
                //await _unitOfWorkManager.Current.SaveChangesAsync();
                var result = ObjectMapper.Map<Appointment, AppointmentDto>(item);
                if (result != null)
                {
                    response.Id = result.Id;
                    response.Value = "";
                    response.Success = true;
                    response.Message = "Consultation complete";
                }
                return response;//ObjectMapper.Map<Appointment, AppointmentDto>(item);
            }
            catch (Exception ex)
            {
                return null;
            }
            return response;
        }

        public async Task UpdateAppointmentPaymentStatusAsync(string appCode, string trnId)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAsync(a => a.AppointmentCode == appCode);
                if (appointment != null && appointment.AppointmentStatus != AppointmentStatus.Confirmed) //&& app.AppointmentStatus != AppointmentStatus.Confirmed)
                {
                    appointment.AppointmentStatus = AppointmentStatus.Confirmed;
                    appointment.PaymentTransactionId = trnId;
                    appointment.AppointmentPaymentStatus = AppointmentPaymentStatus.Paid;
                    //app.FeePaid = string.IsNullOrWhiteSpace(paid_amount) ? 0 : double.Parse(paid_amount);

                    await _appointmentRepository.UpdateAsync(appointment);

                    //await SendNotification(application_code, applicant.Applicant.Mobile);
                }
            }
            catch (Exception ex) { }

        }

        public async Task<string> UpdateAppointmentStatusAfterPaymentAsync(string appCode, int sts)
        {

            var notificatinInput = new NotificationInputDto();
            var notificatin = new NotificationDto();
            var result = "";
            try
            {
                var allAppointment = await _appointmentRepository.WithDetailsAsync();
                var appointment = allAppointment.Where(a => a.AppointmentCode == appCode).FirstOrDefault();
                var allTransactions = await _paymentHistoryRepository.WithDetailsAsync();
                var transactions = allTransactions.Where(p => p.application_code == appCode).FirstOrDefault();

                if (appointment != null && appointment.AppointmentStatus != AppointmentStatus.Confirmed) //&& app.AppointmentStatus != AppointmentStatus.Confirmed)
                {
                    if (sts == 1)
                    {
                        appointment.AppointmentStatus = AppointmentStatus.Confirmed;
                        appointment.PaymentTransactionId = transactions?.tran_id;
                        appointment.AppointmentPaymentStatus = AppointmentPaymentStatus.Paid;

                        //Notifiaction

                        notificatinInput.Message = "Patient " + appointment.PatientName + "  has been scheduled for appointment " + appointment.AppointmentCode + " with doctor " + appointment.DoctorName
                                                              + " by " + appointment.AppointmentCreatorRole + "";
                        notificatinInput.TransactionType = "Add";
                        notificatinInput.CreatorEntityId = appointment.AppointmentCreatorId;
                        if (appointment.AppointmentCreatorRole == "agent")
                        {
                            var agent = await _agentRepository.GetAsync(a => a.Id == appointment.AppointmentCreatorId);
                            notificatinInput.CreatorName = agent.FullName;
                        }
                        else
                        {
                            notificatinInput.CreatorName = appointment.PatientName;
                        }
                        notificatinInput.CreatorRole = appointment.AppointmentCreatorRole;
                        notificatinInput.CreateForName = appointment.PatientName;
                        notificatinInput.NotifyToEntityId = appointment.DoctorProfileId;
                        notificatinInput.NotifyToName = appointment.DoctorName;
                        notificatinInput.NotifyToRole = "Doctor";
                        notificatinInput.NoticeFromEntity = "Appointment";
                        notificatinInput.NoticeFromEntityId = appointment.Id;

                        //
                    }
                    else if (sts == 2)
                    {
                        appointment.AppointmentStatus = AppointmentStatus.Cancelled;
                        appointment.PaymentTransactionId = transactions?.tran_id;
                        appointment.AppointmentPaymentStatus = AppointmentPaymentStatus.FailedOrCancelled;

                        //Notifiaction
                        notificatinInput.Message = "Patient " + appointment.PatientName + "  has been cancelled for appointment " + appointment.AppointmentCode + " with doctor " + appointment.DoctorName
                                                              + " by " + appointment.AppointmentCreatorRole + " due to payment cancelled";
                        notificatinInput.TransactionType = "Add";
                        notificatinInput.CreatorEntityId = appointment.AppointmentCreatorId;
                        if (appointment.AppointmentCreatorRole == "agent")
                        {
                            var agent = await _agentRepository.GetAsync(a => a.Id == appointment.AppointmentCreatorId);
                            notificatinInput.CreatorName = agent.FullName;
                        }
                        else
                        {
                            notificatinInput.CreatorName = appointment.PatientName;
                        }
                        notificatinInput.CreatorRole = appointment.AppointmentCreatorRole;
                        notificatinInput.CreateForName = appointment.PatientName;
                        notificatinInput.NotifyToEntityId = 0;
                        notificatinInput.NotifyToName = "SG Admin";
                        notificatinInput.NotifyToRole = "Admin";
                        notificatinInput.NoticeFromEntity = "Appointment";
                        notificatinInput.NoticeFromEntityId = appointment.Id;
                        // Notification
                    }
                    else if (sts == 3)
                    {
                        appointment.AppointmentStatus = AppointmentStatus.Failed;
                        appointment.PaymentTransactionId = transactions?.tran_id;
                        appointment.AppointmentPaymentStatus = AppointmentPaymentStatus.FailedOrCancelled;

                        //Notifiaction
                        notificatinInput.Message = "Patient " + appointment.PatientName + "  has been failed for appointment " + appointment.AppointmentCode + " with doctor " + appointment.DoctorName
                                                              + " by " + appointment.AppointmentCreatorRole + " due to payment cancelled";
                        notificatinInput.TransactionType = "Add";
                        notificatinInput.CreatorEntityId = appointment.AppointmentCreatorId;
                        if (appointment.AppointmentCreatorRole == "agent")
                        {
                            var agent = await _agentRepository.GetAsync(a => a.Id == appointment.AppointmentCreatorId);
                            notificatinInput.CreatorName = agent.FullName;
                        }
                        else
                        {
                            notificatinInput.CreatorName = appointment.PatientName;
                        }
                        notificatinInput.CreatorRole = appointment.AppointmentCreatorRole;
                        notificatinInput.CreateForName = appointment.PatientName;
                        notificatinInput.NotifyToEntityId = 0;
                        notificatinInput.NotifyToName = "SG Admin";
                        notificatinInput.NotifyToRole = "Admin";
                        notificatinInput.NoticeFromEntity = "Appointment";
                        notificatinInput.NoticeFromEntityId = appointment.Id;
                        // Notification
                    }
                    await _appointmentRepository.UpdateAsync(appointment);

                    var newNotificaitonEntity = ObjectMapper.Map<NotificationInputDto, Notification>(notificatinInput);
                    var notifictionInsert = await _notificationRepository.InsertAsync(newNotificaitonEntity);

                    await _hubContext.Clients.All.BroadcastMessage();//notifictionInsert.Id

                    result = "Appointmnet and Payment Operation Completed.";
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public string testBuildTokenWithUserAccount(string _appId, string _appCertificate, string _channelName, string _account)
        {
            uint privilegeExpiredTs = _expireTimeInSeconds + (uint)Utils.getTimestamp();
            string token = RtcTokenBuilder.buildTokenWithUserAccount(_appId, _appCertificate, _channelName, _account, RtcTokenBuilder.Role.RolePublisher, privilegeExpiredTs);
            return token;
            //Output.WriteLine(">> token");
            //Output.WriteLine(token);
        }

        public string testBuildTokenWithUID(RtcTokenBuilerDto input)
        {
            uint privilegeExpiredTs = _expireTimeInSeconds + (uint)Utils.getTimestamp();
            string token = RtcTokenBuilder.buildTokenWithUID(input.Appid, input.AppCertificate, input.ChanelName, input.Uid, RtcTokenBuilder.Role.RolePublisher, privilegeExpiredTs);
            return token;
            //Output.WriteLine(">> token");
            //Output.WriteLine(token);
        }
        //public string testAcToken(RtcTokenBuilerDto input)
        //{
        //    uint privilegeExpiredTs = _expireTimeInSeconds + (uint)Utils.getTimestamp();
        //    AccessToken accessToken = new AccessToken(input.Appid, input.AppCertificate, input.ChanelName, input.Uid.ToString(), privilegeExpiredTs, 1);
        //    accessToken.addPrivilege(Privileges.kJoinChannel, privilegeExpiredTs);
        //    accessToken.addPrivilege(Privileges.kPublishAudioStream, privilegeExpiredTs);
        //    accessToken.addPrivilege(Privileges.kPublishVideoStream, privilegeExpiredTs);
        //    accessToken.addPrivilege(Privileges.kPublishDataStream, privilegeExpiredTs);

        //    string token = accessToken.build();
        //    return token;
        //    //Output.WriteLine(">> token");
        //    //Output.WriteLine(token);
        //}
    }
}
