using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using SoowGoodWeb.DtoModels;
using SoowGoodWeb.Enums;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using SoowGoodWeb.Utilities;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Uow;
using IdentityModel.Client;
using System.Text;

namespace SoowGoodWeb.Services
{
    //[Authorize]
    public class OtpService : SoowGoodWebAppService, IOtpService
    {

        private readonly IdentityUserManager _userManager;
        private readonly IRepository<Otp, int> _repository;
        private readonly ISmsService _smsService;
        private readonly IRepository<DoctorProfile> _doctorProfileRepository;
        private readonly IRepository<PatientProfile> _patientProfileRepository;
        private readonly IRepository<AgentProfile> _agentProfileRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public OtpService(IdentityUserManager userManager, IRepository<Otp, int> repository,
            IRepository<DoctorProfile> doctorProfileRepository,
            IRepository<PatientProfile> patientProfileRepository,
            IRepository<AgentProfile> agentProfileRepository,
            ISmsService smsService,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _userManager = userManager;
            _agentProfileRepository = agentProfileRepository;
            _doctorProfileRepository = doctorProfileRepository;
            _patientProfileRepository = patientProfileRepository;
            this._repository = repository;
            this._smsService = smsService;
            this._unitOfWorkManager = unitOfWorkManager;
        }


        //[HttpGet]
        //[AllowAnonymous]

        public async Task<bool> ApplyOtp(string clientKey, string mobileNo)
        {
            int exits = 0;
            var doctors = await _doctorProfileRepository.GetListAsync();//(d => d.MobileNo==mobileNo);
            var doctor = doctors.FirstOrDefault(d => d.MobileNo == mobileNo);

            if (doctor == null)
            {
                var patients = await _patientProfileRepository.GetListAsync();//.GetAsync(p => p.MobileNo==mobileNo);
                var patient = patients.FirstOrDefault(p => p.MobileNo == mobileNo);
                if (patient == null)
                {
                    var agents = await _agentProfileRepository.GetListAsync();//.GetAsync(a => a.MobileNo==mobileNo);
                    var agent = agents.FirstOrDefault(a => a.MobileNo == mobileNo);
                    if (agent == null)
                    {
                        exits = 0;
                    }
                    else
                    {
                        exits = 1;
                    }
                }
                else
                {
                    exits = 1;
                }
            }
            else
            {
                exits = 1;
            }
            if (exits == 0)
            {
                if (!string.IsNullOrEmpty(clientKey) && clientKey.Equals("SoowGood_App", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(mobileNo))
                {
                    int otp = Utility.GetRandomNo(1000, 9999);
                    Otp otpEntity = new Otp();
                    otpEntity.OtpNo = otp;
                    otpEntity.MobileNo = mobileNo;
                    otpEntity.ExpireDateTime = DateTime.Now.AddMinutes(3);
                    otpEntity.OtpStatus = OtpStatus.New;
                    await _repository.InsertAsync(otpEntity);
                    // stp start
                    SmsRequestParamDto otpInput = new SmsRequestParamDto();
                    otpInput.Sms = String.Format(otp + " is your OTP to authenticate your Phone No. Do not share this OTP with anyone.");
                    otpInput.Msisdn = mobileNo;
                    otpInput.CsmsId = GenerateTransactionId(16);
                    try
                    {
                        var res = await _smsService.SendSmsGreenWeb(otpInput);
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                        throw new Exception(e.Message);
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }


        [AllowAnonymous]
        public virtual async Task<bool> IsExist(string mobile)
        {
            UserSignUpResultDto result = new UserSignUpResultDto();
            using (var client = new HttpClient())
            {
                var tokenResponse = await GetToken();
                client.BaseAddress = new Uri(PermissionHelper._identityClientUrl);
                client.SetBearerToken(tokenResponse.AccessToken);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method

                //var update = JsonSerializer.Serialize(userDto);
                //var requestContent = new StringContent(update, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.GetAsync($"api/app/account/IsUserExist?mobile={mobile}");
                if (response.IsSuccessStatusCode)
                {

                    return true;

                }
            }
            return false;
        }
        private async Task<TokenResponse> GetToken()
        {
            var authorityUrl = $"{PermissionHelper._authority}";

            var authority = new HttpClient();
            var discoveryDocument = await authority.GetDiscoveryDocumentAsync(authorityUrl);
            if (discoveryDocument.IsError)
            {
                //return null;
            }

            // Request Token
            var tokenResponse = await authority.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = PermissionHelper._clientId,
                ClientSecret = PermissionHelper._clientSecret,
                Scope = PermissionHelper._scope
            });

            if (tokenResponse.IsError)
            {
                //return null;
            }
            return tokenResponse;
        }
        private static string GenerateTransactionId(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //[HttpGet]
        public async Task<bool> VarifyOtpAsync(int otp)
        {

            if (otp > 0)
            {
                var item = await _repository.FirstOrDefaultAsync(x => x.OtpNo == otp && x.OtpStatus == OtpStatus.New && x.ExpireDateTime >= DateTime.Now);
                if (item != null)
                {
                    item.OtpStatus = OtpStatus.Varified;
                    await _repository.UpdateAsync(item);
                    await _unitOfWorkManager.Current.SaveChangesAsync();
                    return true;
                }
            }
            return false;
            //return true;
        }

        public async Task<OtpDto> UpdateAsync(OtpDto input)
        {
            var item = await _repository.FirstOrDefaultAsync(x => x.OtpNo == input.OtpNo && x.ExpireDateTime >= DateTime.Now);
            if (item != null)
            {
                item.OtpStatus = input.OtpStatus;
                await _repository.UpdateAsync(item);
                return ObjectMapper.Map<Otp, OtpDto>(item);
            }
            return input;
        }

        public async Task<bool> IsDoctorExist(string mobile)
        {
            var doctor = await _doctorProfileRepository.GetAsync(d => d.MobileNo == mobile);
            if (doctor != null)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> IsPatientExist(string mobile)
        {
            var doctor = await _patientProfileRepository.GetAsync(d => d.MobileNo == mobile);
            if (doctor != null)
            {
                return true;
            }
            else { return false; }
        }
        public async Task<bool> IsAgentExist(string mobile)
        {
            var doctor = await _agentProfileRepository.GetAsync(d => d.MobileNo == mobile);
            if (doctor != null)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> ApplyOtpForPasswordReset(string clientKey, string? role, string mobileNo)
        {
            int exits = 0;
            var doctors = await _doctorProfileRepository.GetListAsync();//(d => d.MobileNo==mobileNo);

            if (role == "agent")
            {
                var agents = await _agentProfileRepository.GetListAsync();//.GetAsync(a => a.MobileNo==mobileNo);
                var agent = agents.FirstOrDefault(a => a.MobileNo == mobileNo);
                if (agent == null)
                {
                    exits = 0;
                }
                else
                {
                    exits = 1;
                }
            }
            else
            {
                var doctor = doctors.FirstOrDefault(d => d.MobileNo == mobileNo);

                if (doctor == null)
                {
                    var patients = await _patientProfileRepository.GetListAsync();//.GetAsync(p => p.MobileNo==mobileNo);
                    var patient = patients.FirstOrDefault(p => p.MobileNo == mobileNo);
                    if (patient == null)
                    {
                        exits = 0;
                    }
                    else
                    {
                        exits = 1;
                    }
                }
                else
                {
                    exits = 1;
                }
            }
            if (exits == 1)
            {
                if (!string.IsNullOrEmpty(clientKey) && clientKey.Equals("SoowGood_App", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(mobileNo))
                {
                    int otp = Utility.GetRandomNo(1000, 9999);
                    Otp otpEntity = new Otp();
                    otpEntity.OtpNo = otp;
                    otpEntity.MobileNo = mobileNo;
                    otpEntity.ExpireDateTime = DateTime.Now.AddMinutes(3);
                    otpEntity.OtpStatus = OtpStatus.New;
                    await _repository.InsertAsync(otpEntity);
                    // stp start
                    SmsRequestParamDto otpInput = new SmsRequestParamDto();
                    otpInput.Sms = String.Format(otp + " is your OTP to authenticate your Phone No. Do not share this OTP with anyone.");
                    otpInput.Msisdn = mobileNo;
                    otpInput.CsmsId = GenerateTransactionId(16);
                    try
                    {
                        var res = await _smsService.SendSmsGreenWeb(otpInput);
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                        throw new Exception(e.Message);
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

    }
}


