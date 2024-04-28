using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using SoowGoodWeb.EkPayData;
//using SoowGoodWeb.EkPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using SoowGoodWeb.Enums;
using static System.Net.WebRequestMethods;

namespace SoowGoodWeb.Services
{
    public class EkPayService : SoowGoodWebAppService, IEkPayService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IRepository<PatientProfile> _patientRepository;
        private readonly IPaymentHistoryService _paymentHistoryService;
        private readonly IRepository<PaymentHistory> _paymentHistoryRepository;
        //private readonly INotificationAppService _notificationAppService;
        private readonly EkPayGatewayManager _ekPayGatewayManager;

        //INotificationAppService notificationAppService,
        public EkPayService(IRepository<Appointment> appointmentRepository,
            IRepository<PatientProfile> patientRepository,
            IRepository<PaymentHistory> paymentHistoryRepository,
                                    IPaymentHistoryService paymentHistoryService,
                                    EkPayGatewayManager ekPayGatewayManager)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _paymentHistoryService = paymentHistoryService;
            _paymentHistoryRepository = paymentHistoryRepository;
            //_notificationAppService = notificationAppService;
            _ekPayGatewayManager = ekPayGatewayManager;
        }


        //[HttpPost]
        public async Task<EkPayInitDto> InitiatePaymentAsync(EkPayInputDto input)
        {
            //return new EkPayInitDto();
            input.TransactionId = GenerateTransactionId(16);

            var applicantData = await GetApplicantDetails(input);

            var postData = _ekPayGatewayManager.CreateDataRaw(applicantData);//.CreateDataRaw(applicantData);

            var initResponse = await _ekPayGatewayManager.InitiatePaymentAsync(postData);

            await InitPaymentHistory(input, initResponse);

            return GetInitPaymentResponse(initResponse, input.TransactionId);
        }

        private async Task InitPaymentHistory(EkPayInputDto input, EkPayTokenResponse initResponse)
        {
            await _paymentHistoryService.CreateAsync(new PaymentHistoryInputDto
            {
                amount = input.TotalAmount,
                status = initResponse.msg_code,
                tran_id = input.TransactionId,
                sessionkey = initResponse.secure_token,
                failedreason = initResponse.responseCode!=null?initResponse.responseMessage: "",
                application_code = input.ApplicationCode
            });
        }

        //[HttpGet]
        //public async Task<TransactionValidationDto> ValidateTransactionAsync(Dictionary<string, string> responseDic)
        //{
        //    return await _ekPayGatewayManager.ValidateTransactionAsync(responseDic);
        //}

        ////[HttpGet]
        //public async Task<bool> InitiateRefundAsync()
        //{
        //    var response = await Task.Run(() =>
        //    {
        //        return _ekPayGatewayManager.InitiateRefundAsync();
        //    });
        //    return response;
        //}

        //[HttpPost]
        public async Task<EkPayInitDto> InitiateTestPaymentAsync(EkPayInputDto input)
        {
            //var nuDto = new EkPayInitDto();

            input.TransactionId = GenerateTransactionId(16);

            var applicantData = await GetApplicantDetails(input);

            var postData = _ekPayGatewayManager.CreateTestDataRaw(applicantData);//.CreateDataRaw(applicantData);

            var initResponse = await _ekPayGatewayManager.InitiateTestPaymentAsync(postData);

            await InitPaymentHistory(input, initResponse);

            return GetInitTestPaymentResponse(initResponse, input.TransactionId);
        }

        //[HttpGet]
        //public async Task<TransactionValidationDto> ValidateTestTransactionAsync(Dictionary<string, string> responseDic)
        //{
        //    return await _ekPayGatewayManager.ValidateTestTransactionAsync(responseDic);
        //}


        //[HttpGet]
        public async Task<bool> InitiateTestRefundAsync()
        {
            var response = await Task.Run(() =>
            {
                return _ekPayGatewayManager.InitiateTestRefundAsync();
            });
            return response;
        }

        private async Task<EkPayDataRawDto> GetApplicantDetails(EkPayInputDto input)
        {
            var nDto = new EkPayDataRawDto();
            return await Task.Run(async () =>
            {
                var app = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
                var job = app.Where(a => a.AppointmentCode == input.ApplicationCode).FirstOrDefault();
                var ekPayPostDataDto = new EkPayDataRawDto();
                if (job != null && job.AppointmentStatus == AppointmentStatus.Pending)
                {
                    var patient = await _patientRepository.GetAsync(p => p.Id == job.PatientProfileId);

                    ekPayPostDataDto.cust_email = patient.Email;
                    ekPayPostDataDto.cust_id = patient.PatientCode;
                    ekPayPostDataDto.cust_mail_addr = patient.Address;
                    ekPayPostDataDto.cust_mobo_no = patient.PatientMobileNo;
                    ekPayPostDataDto.cust_name = patient.PatientName;

                    ekPayPostDataDto.ord_det = input.ApplicationCode;
                    ekPayPostDataDto.ord_id = job.Id.ToString();
                    ekPayPostDataDto.trnx_amt = input.TotalAmount;
                    ekPayPostDataDto.trnx_currency = "BDT";
                    ekPayPostDataDto.trnx_id = input.TransactionId;

                }

                return ekPayPostDataDto;
            });
        }

        public async Task UpdatePaymentHistory(Dictionary<string, string> ekPayResponseDic)
        {
            ekPayResponseDic.TryGetValue("tran_id", out string tran_id);
            if (!string.IsNullOrWhiteSpace(tran_id))
            {
                var paymentHistory = await _paymentHistoryService.GetByTranIdAsync(tran_id);
                if (paymentHistory != null)
                {
                    var paymentHistoryInputDto = GetPaymentHistoryDto(ekPayResponseDic, paymentHistory);
                    await _paymentHistoryService.UpdateHistoryAsync(paymentHistoryInputDto);
                }
            }
        }

        public async Task UpdateApplicantPaymentStatus(Dictionary<string, string> ekPayResponseDic)
        {
            ekPayResponseDic.TryGetValue("tran_id", out string tran_id);
            if (!string.IsNullOrWhiteSpace(tran_id))
            {
                var paymentHistory = await _paymentHistoryService.GetByTranIdAsync(tran_id);
                if (paymentHistory != null)
                {
                    if (!string.IsNullOrWhiteSpace(paymentHistory.application_code))
                    {
                        ekPayResponseDic.TryGetValue("amount", out string paid_amount);
                        await UpdatePaymentStatus(paymentHistory.application_code, tran_id, paid_amount);
                    }
                }
            }
        }

        private async Task UpdatePaymentStatus(string application_code, string tran_id, string paid_amount)
        {
            var applicant = await _appointmentRepository.WithDetailsAsync(s => s.DoctorSchedule);
            var app = applicant.Where(a => a.AppointmentCode == application_code).FirstOrDefault();

            if (app != null) //&& app.AppointmentStatus != AppointmentStatus.Confirmed)
            {
                app.AppointmentStatus = AppointmentStatus.Confirmed;
                app.PaymentTransactionId = tran_id;
                app.AppointmentPaymentStatus = AppointmentPaymentStatus.Paid;
                //app.FeePaid = string.IsNullOrWhiteSpace(paid_amount) ? 0 : double.Parse(paid_amount);

                await _appointmentRepository.UpdateAsync(app);

                //await SendNotification(application_code, applicant.Applicant.Mobile);
            }
        }

        //private async Task SendNotification(string application_code, string msisdn)
        //{
        //    var smsInput = new SmsRequestInput
        //    {
        //        msisdn = msisdn,
        //        csms_id = GenerateTransactionId(16),
        //        sms = $"আপনার  আবেদনটি সফলভাবে সম্পন্ন হয়েছে। আপনার আবেদন কোডঃ {application_code}"
        //    };

        //    await _notificationAppService.SendSmsNotification(smsInput);
        //}

        private PaymentHistoryInputDto GetPaymentHistoryDto(Dictionary<string, string> ekPayResponseDic, PaymentHistoryDto paymentHistoryDto)
        {
            ekPayResponseDic.TryGetValue("tran_id", out string tran_id);
            ekPayResponseDic.TryGetValue("val_id", out string val_id);
            ekPayResponseDic.TryGetValue("amount", out string amount);
            ekPayResponseDic.TryGetValue("card_type", out string card_type);
            ekPayResponseDic.TryGetValue("store_amount", out string store_amount);
            ekPayResponseDic.TryGetValue("card_no", out string card_no);
            ekPayResponseDic.TryGetValue("bank_tran_id", out string bank_tran_id);
            ekPayResponseDic.TryGetValue("status", out string status);
            ekPayResponseDic.TryGetValue("tran_date", out string tran_date);
            ekPayResponseDic.TryGetValue("error", out string error);
            ekPayResponseDic.TryGetValue("currency", out string currency);
            ekPayResponseDic.TryGetValue("card_issuer", out string card_issuer);
            ekPayResponseDic.TryGetValue("card_brand", out string card_brand);
            ekPayResponseDic.TryGetValue("card_sub_brand", out string card_sub_brand);
            ekPayResponseDic.TryGetValue("card_issuer_country", out string card_issuer_country);
            ekPayResponseDic.TryGetValue("card_issuer_country_code", out string card_issuer_country_code);
            ekPayResponseDic.TryGetValue("currency_type", out string currency_type);
            ekPayResponseDic.TryGetValue("currency_amount", out string currency_amount);
            ekPayResponseDic.TryGetValue("currency_rate", out string currency_rate);
            ekPayResponseDic.TryGetValue("base_fair", out string base_fair);
            ekPayResponseDic.TryGetValue("value_a", out string value_a);
            ekPayResponseDic.TryGetValue("value_b", out string value_b);
            ekPayResponseDic.TryGetValue("value_c", out string value_c);
            ekPayResponseDic.TryGetValue("value_d", out string value_d);
            ekPayResponseDic.TryGetValue("subscription_id", out string subscription_id);
            ekPayResponseDic.TryGetValue("risk_level", out string risk_level);
            ekPayResponseDic.TryGetValue("risk_title", out string risk_title);

            var paymentHistoryInputDto = new PaymentHistoryInputDto
            {
                Id = 0,
                sessionkey = paymentHistoryDto.sessionkey,
                application_code = paymentHistoryDto.application_code,
                tran_id = tran_id,
                val_id = val_id,
                amount = amount,
                card_type = card_type,
                store_amount = store_amount,
                card_no = card_no,
                bank_tran_id = bank_tran_id,
                status = status,
                tran_date = tran_date,
                failedreason = error,
                error = error,
                currency = currency,
                card_issuer = card_issuer,
                card_brand = card_brand,
                card_sub_brand = card_sub_brand,
                card_issuer_country = card_issuer_country,
                card_issuer_country_code = card_issuer_country_code,
                currency_type = currency_type,
                currency_amount = currency_amount,
                currency_rate = currency_rate,
                base_fair = base_fair,
                value_a = value_a,
                value_b = value_b,
                value_c = value_c,
                value_d = value_d,
                subscription_id = subscription_id,
                risk_level = risk_level,
                risk_title = risk_title
            };

            return paymentHistoryInputDto;
        }

        private static string GenerateTransactionId(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static EkPayInitDto GetInitPaymentResponse(EkPayTokenResponse initResponse, string trnsId)
        {
            var pResponse = new EkPayInitDto();
            //pResponse =
            pResponse.status = initResponse.responseCode != null ? initResponse.responseCode : initResponse.msg_code;
            pResponse.message = initResponse.responseMessage != null ? initResponse.responseMessage : initResponse.msg_det;
            pResponse.GatewayPageURL = initResponse.responseCode == null && initResponse.responseMessage == null ? "https://pg.ekpay.gov.bd/ekpaypg/v1?sToken=" + initResponse.secure_token+ "&trnsID=" + trnsId:"";

            return pResponse;
        }

        private static EkPayInitDto GetInitTestPaymentResponse(EkPayTokenResponse initResponse, string trnsId)
        {
            var pResponse = new EkPayInitDto();
            //pResponse =
            pResponse.status = initResponse.responseCode != null ? initResponse.responseCode : initResponse.msg_code;
            pResponse.message = initResponse.responseMessage != null ? initResponse.responseMessage : initResponse.msg_det;
            pResponse.GatewayPageURL = initResponse.responseCode == null && initResponse.responseMessage == null ? "https://sandbox.ekpay.gov.bd/ekpaypg/v1?sToken=" + initResponse.secure_token + "&trnsID=" + trnsId : "";

            return pResponse;
        }

        private static EkPayDto GetFullInitPaymentResponse(EkPayInitResponse initResponse)
        {
            return new EkPayDto
            {
                status = initResponse.status,
                sessionkey = initResponse.sessionkey,
                failedreason = initResponse.failedreason,
                redirectGatewayURL = initResponse.redirectGatewayURL,
                directPaymentURLBank = initResponse.directPaymentURLBank,
                directPaymentURLCard = initResponse.directPaymentURLCard,
                directPaymentURL = initResponse.directPaymentURL,
                redirectGatewayURLFailed = initResponse.redirectGatewayURLFailed,
                GatewayPageURL = initResponse.GatewayPageURL,
                storeBanner = initResponse.storeBanner,
                storeLogo = initResponse.storeLogo,
                store_name = initResponse.store_name,
                is_direct_pay_enable = initResponse.is_direct_pay_enable
            };
        }

        public async Task UpdateAppointmentPaymentStatusAsync(string appCode)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAsync(a => a.AppointmentCode == appCode);
                var transactions = await _paymentHistoryRepository.GetAsync(p => p.application_code == appCode);
                if (appointment != null && appointment.AppointmentStatus != AppointmentStatus.Confirmed) //&& app.AppointmentStatus != AppointmentStatus.Confirmed)
                {
                    appointment.AppointmentStatus = AppointmentStatus.Confirmed;
                    appointment.PaymentTransactionId = transactions.tran_id;
                    appointment.AppointmentPaymentStatus = AppointmentPaymentStatus.Paid;
                    //app.FeePaid = string.IsNullOrWhiteSpace(paid_amount) ? 0 : double.Parse(paid_amount);

                    await _appointmentRepository.UpdateAsync(appointment);

                    //await SendNotification(application_code, applicant.Applicant.Mobile);
                }
            }
            catch (Exception ex) { }

        }
    }
}
