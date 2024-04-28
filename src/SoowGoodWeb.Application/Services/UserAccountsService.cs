using Microsoft.AspNetCore.Authorization;
using SoowGoodWeb.DtoModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Emailing;
using Volo.Abp.Identity;
using Volo.Abp;
using Microsoft.AspNetCore.Identity;
using System.Transactions;
using SoowGoodWeb.Models;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using System.Net.Http;
using IdentityModel.Client;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using System.Linq;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Nancy;
using System.Numerics;
using Volo.Abp.Users;
//using System.IdentityModel.Tokens.Jwt;
////using System.IdentityModel.Tokens.Jwt;

namespace SoowGoodWeb.Services
{

    public class UserAccountsService : SoowGoodWebAppService
    {
        string authClientUrl = PermissionHelper._identityClientUrl;
        string authUrl = PermissionHelper._authority;

        private readonly IdentityUserManager _userManager;
        //private readonly IdentityRoleManager _roleManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRepository<DoctorProfile> _doctorProfileRepository;
        private readonly IRepository<PatientProfile> _patientProfileRepository;
        private readonly IRepository<AgentProfile> _agentProfileRepository;

        private readonly IUnitOfWorkManager _unitOfWorkManager;
        //private readonly DoctorProfileService _doctorProfileservice;

        private readonly IEmailSender _emailSender;

        public UserAccountsService(IdentityUserManager userManager,
                                   //IdentityRoleManager roleManager,
                                   //SignInManager<IdentityUser> signInManager,
                                   IRepository<DoctorProfile> doctorProfileRepository,
                                   IRepository<PatientProfile> patientProfileRepository,
                                   IRepository<AgentProfile> agentProfileRepository,
                                   IUnitOfWorkManager unitOfWorkManager,
                                   IEmailSender emailSender)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
            //_signInManager = signInManager;
            _doctorProfileRepository = doctorProfileRepository;
            _patientProfileRepository = patientProfileRepository;
            _agentProfileRepository = agentProfileRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _emailSender = emailSender;
            //_doctorProfileservice = new DoctorProfileService(_doctorProfileRepository, _unitOfWorkManager);
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

        [AllowAnonymous]
        public async Task<bool> RefreshAccessToken(IdentityUser user)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _userManager.RemoveAuthenticationTokenAsync(user, "SoowGoodWeb", "RefreshToken");
                    var newRefreshToken = await _userManager.GenerateUserTokenAsync(user, "SoowGoodWeb", "RefreshToken");
                    var result = await _userManager.SetAuthenticationTokenAsync(user, "SoowGoodWeb", "RefreshToken", newRefreshToken);

                    scope.Complete();
                    return result.Succeeded;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        //public async Task<string> GetUinfo(string tok)
        //{
        //    var hc = new HttpClient();
        //    hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tok);
        //    var response = hc.GetAsync(PermissionHelper._authority).Result;
        //    var userInfo = response.Content.ReadAsStringAsync().Result;
        //    return userInfo;
        //}
        public async Task<LoginResponseDto> Login(LoginDto userDto)
        {
            LoginResponseDto result = new LoginResponseDto();
            using (var client = new HttpClient())
            {
                var tokenResponse = await GetToken();
                client.BaseAddress = new Uri(authClientUrl);
                client.SetBearerToken(tokenResponse.AccessToken);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var update = JsonSerializer.Serialize(userDto);
                var requestContent = new StringContent(update, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(($"api/app/account/login"), requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var newUserString = await response.Content.ReadAsStringAsync();
                    var newUser = JsonConvert.DeserializeObject<LoginResponseDto>(newUserString);

                    result = new LoginResponseDto()
                    {
                        UserId = newUser?.UserId,
                        UserName = newUser?.UserName,
                        RoleName = newUser?.RoleName,
                        Success = newUser.Success,
                        Message = newUser.Message
                    };
                    return result;
                }
                return result;
                //var user = await _userManager.FindByNameAsync(userDto.UserName);
                //LoginResponseDto loginInfo = new LoginResponseDto();
                //loginInfo.RoleName = new List<string>();
                //if (user != null)
                //{
                //    var userole = await _userManager.GetRolesAsync(user); //_roleManager.GetRolesAsync(user);

                //    var res = await _signInManager.PasswordSignInAsync(user.UserName, userDto.password, userDto.RememberMe, lockoutOnFailure: false);
                //    if (res.Succeeded)
                //    {
                //        loginInfo.UserId = user.Id;
                //        loginInfo.UserName = user.UserName;
                //        foreach (string r in userole)
                //        {
                //            loginInfo.RoleName.Add(r);
                //        }
                //        loginInfo.Success = true;
                //        loginInfo.Message = "User Exists! Login Successful!";
                //        return loginInfo;
                //    }
                //    else
                //    {
                //        loginInfo.UserId = null;
                //        loginInfo.UserName = "";
                //        loginInfo.Success = false;
                //        loginInfo.Message = "User Name Or Password is not correct !";
                //        return loginInfo;
                //    }
                //}
                //else
                //{
                //    loginInfo.UserId = null;
                //    loginInfo.UserName = "";
                //    loginInfo.Success = false;
                //    loginInfo.Message = "User not exists! Please sign up as new user";
                //    return loginInfo;
                //}
            }

        }

        [AllowAnonymous]
        public virtual async Task<UserSignUpResultDto> SignupUser(UserInfoDto userDto, string password, string role)
        {
            UserSignUpResultDto result = new UserSignUpResultDto();
            using (var client = new HttpClient())
            {
                var tokenResponse = await GetToken();
                client.BaseAddress = new Uri(authClientUrl);
                client.SetBearerToken(tokenResponse.AccessToken);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method

                var update = JsonSerializer.Serialize(userDto);
                var requestContent = new StringContent(update, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(($"api/app/account/sign-up?password={password}&role={role}"), requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var newUserString = await response.Content.ReadAsStringAsync();
                    var newUser = JsonConvert.DeserializeObject<UserSignUpResultDto>(newUserString);

                    result = new UserSignUpResultDto()
                    {
                        UserId = newUser?.UserId,
                        UserName = newUser?.UserName,
                        Name = newUser?.Name,
                        Email = newUser?.Email,
                        PhoneNumber = newUser?.PhoneNumber,
                        Success = newUser?.Success,
                        Message = newUser.Message.ToList(),

                    };
                    return result;

                }
            }
            return result;
        }

        //[AllowAnonymous]
        public virtual async Task<ResetPasswordResponseDto> ResetPassword(ResetPasswordInputDto inputDto)
        {
            ResetPasswordResponseDto result = new ResetPasswordResponseDto();
            using (var client = new HttpClient())
            {
                var tokenResponse = await GetToken();
                client.BaseAddress = new Uri(authClientUrl);
                client.SetBearerToken(tokenResponse.AccessToken);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method

                var update = JsonSerializer.Serialize(inputDto);
                var requestContent = new StringContent(update, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(($"api/app/account/reset-password"), requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var newUserString = await response.Content.ReadAsStringAsync();
                    var newUser = JsonConvert.DeserializeObject<ResetPasswordResponseDto>(newUserString);

                    result = new ResetPasswordResponseDto()
                    {
                        //UserId = newUser?.UserId,
                        UserName = newUser?.UserName,
                        Name = newUser?.Name,
                        //Email = newUser?.Email,
                        //PhoneNumber = newUser?.PhoneNumber,
                        Success = newUser?.Success,
                        Message = newUser?.Message//.ToList(),

                    };
                    return result;

                }
            }
            return result;
        }
        // POST /api/account/reset-password
        public async Task<ResetPasswordResponseDto> ResetPassword_App(ResetPasswordInputDto inputDto)
        {
            ResetPasswordResponseDto result = new ResetPasswordResponseDto();
            try
            {
                var mainUser = await _userManager.FindByNameAsync(inputDto.UserId);
                if (mainUser != null)
                {
                    string userId = mainUser.Id.ToString();
                    if (!string.IsNullOrEmpty(userId))
                    {
                        var user = await _userManager.FindByIdAsync(userId);
                        if (user != null)
                        {
                            var removePwd = await _userManager.RemovePasswordAsync(user);
                            if (removePwd.Succeeded)
                            {
                                var addnewPwd = await _userManager.AddPasswordAsync(user, inputDto.NewPassword);
                                if (addnewPwd.Succeeded)
                                {
                                    var updateUser = await _userManager.UpdateAsync(user);
                                    if (updateUser.Succeeded)
                                    {
                                        result.UserName = inputDto.UserId.ToString();
                                        result.Name = user.Name;
                                        result.Success = true;
                                        result.Message = "Dear Mr. " + user.Name + ",Your Password Updated Successfully at SoowGood.com. You can login now with your new password.";

                                    }
                                    else // if (updateUser.Errors.Count() > 0)
                                    {

                                        result.Success = false;
                                        foreach (var error in updateUser.Errors)
                                        {
                                            result.Message = "Password Reset Failed for. " + error;
                                        }
                                    }
                                }
                                else //if (addnewPwd.Errors.Count() > 0)
                                {

                                    result.Success = false;
                                    foreach (var error in addnewPwd.Errors)
                                    {
                                        result.Message = "Password Reset Failed for. " + error;
                                    }
                                }
                            }
                            else //if (removePwd.Errors.Count() > 0)
                            {

                                result.Success = false;
                                foreach (var error in removePwd.Errors)
                                {
                                    result.Message = "Password Reset Failed for. " + error;
                                }
                            }
                        }
                        else //if (removePwd.Errors.Count() > 0)
                        {
                            result.Success = false;
                            result.Message = "User not found !!!";
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new UserFriendlyException("Password reset not successfull.");
            }
            return result;
        }
        public async Task<bool> IsUserExists(string userName)
        {

            var allDoctors = await _doctorProfileRepository.GetListAsync();
            if (allDoctors.Any())
            {
                var doctor = allDoctors.FirstOrDefault(d => d.MobileNo == userName);
                if (doctor != null && doctor.Id > 0)
                {
                    return true;
                }
                else
                {
                    var allPatient = await _patientProfileRepository.GetListAsync();
                    if (allPatient.Any())
                    {
                        var patient = allPatient.FirstOrDefault(p => p.MobileNo == userName);
                        if (patient != null && patient.Id > 0)
                        {
                            return true;
                        }
                        else
                        {
                            var allAgent = await _agentProfileRepository.GetListAsync();
                            if (allAgent.Any())
                            {
                                var agent = allAgent.FirstOrDefault(a => a.MobileNo == userName);
                                if (agent != null && agent.Id > 0)
                                {
                                    return true;
                                }
                                else { return false; }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public async Task<AccountDeteleResponsesDto> UserDataRemoveAsync(DeleteUserDataDto userData, string role)
        {
            //var doctorDelete = null;
            bool profileDeleted = false;
            Guid? userId;
            var authresult = new AccountDeteleResponsesDto();
            var result = new AccountDeteleResponsesDto();
            try
            {

                using (var client = new HttpClient())
                {
                    var tokenResponse = await GetToken();
                    client.BaseAddress = new Uri(authClientUrl);
                    client.SetBearerToken(tokenResponse.AccessToken);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method

                    var update = JsonSerializer.Serialize(userData);
                    var requestContent = new StringContent(update, Encoding.UTF8, "application/json");
                    HttpResponseMessage response =
                        await client.PostAsync($"api/app/account/user-data-remove", requestContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var newUserString = await response.Content.ReadAsStringAsync();
                        var newUser = JsonConvert.DeserializeObject<AccountDeteleResponsesDto>(newUserString);

                        authresult = new AccountDeteleResponsesDto()
                        {
                            Success = newUser.Success,
                            //Message = newUser.Message//"User Account removed"

                        };
                        if (authresult.Success == true)
                        {
                            if (role == "Doctor")
                            {
                                var doctor = await _doctorProfileRepository.GetAsync(d => d.MobileNo == userData.UserName);
                                userId = doctor.UserId;
                                var doctorDelete = _doctorProfileRepository.DeleteAsync(doctor);
                                //profileDeleted = true;
                                if (doctorDelete != null)
                                {
                                    result.Success = true;
                                    result.Message = "User Account removed";
                                }
                            }
                            else if (role == "Patient")
                            {
                                var patient = await _patientProfileRepository.GetAsync(d => d.MobileNo == userData.UserName);
                                userId = patient.UserId;
                                var doctorDelete = _patientProfileRepository.DeleteAsync(patient);
                                //profileDeleted = true;
                                if (doctorDelete != null)
                                {
                                    result.Success = true;
                                    result.Message = "User Account removed";
                                }
                            }
                        }
                        //return result;

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        //public static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
        //{
        //    var handler = new JwtSecurityTokenHandler();
        //    var token = handler.ReadJwtToken(jwt);

        //    return token;
        //}

        public async Task<PatientDetailsForServiceDto> DecodeJwt(JAccessToken jwt)
        {
            //var doctorDelete = null;
            bool profileDeleted = false;
            Guid? userId;
            var result = new PatientDetailsForServiceDto();
            try
            {

                using (var client = new HttpClient())
                {
                    var tokenResponse = await GetToken();
                    client.BaseAddress = new Uri(authClientUrl);
                    client.SetBearerToken(tokenResponse.AccessToken);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method

                    var update = JsonSerializer.Serialize(jwt);
                    var requestContent = new StringContent(update, Encoding.UTF8, "application/json");
                    HttpResponseMessage response =
                        await client.PostAsync($"api/app/account/retrieve-user-name", requestContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var newUserString = await response.Content.ReadAsStringAsync();
                        var newUser = JsonConvert.DeserializeObject<PatientDetailsForServiceDto>(newUserString);

                        if (newUser?.Role == "Patient")
                        {
                            result.Success = true;
                            result.UserNmae = newUser?.UserNmae;
                            result.Role = newUser?.Role;
                            var patientDetails = await _patientProfileRepository.GetAsync(p => p.MobileNo == result.UserNmae);
                            if (patientDetails != null)
                            {
                                result.PatientProfileId = patientDetails.Id;
                                result.PatientCode = patientDetails.PatientCode;
                                result.PatientName = patientDetails.FullName;
                            }                            
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "User Not a patient! Please login as a patient to avail the services...";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }


}

