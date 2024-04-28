using SoowGoodWeb.DtoModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.PermissionManagement;
using SoowGoodWeb.Interfaces;
using Newtonsoft.Json.Linq;
using System.Net;

namespace SoowGoodWeb.Services
{
    public class SmsService : SoowGoodWebAppService, ISmsService
    {
        //private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public SmsService(ILogger<PermissionAppService> logger)
        {
            _logger = logger;
            //_httpClient = CreateClient();
        }

        //public async Task<SmsResponse> SendSmsNotification(SmsRequestInput input)
        //{
        //    HttpClient client = new HttpClient();
        //    var requestInput = new Dictionary<string, string>
        //    {
        //        { "api_token", "pnij27vt-wixyw8qu-a4rwdexc-kqvpgude-tt32mdiv" },
        //        { "sid", "PWDNONAPI" }
        //    };

        //    requestInput.Add("msisdn", input.Msisdn);
        //    requestInput.Add("sms", input.Sms);
        //    requestInput.Add("csms_id", input.CsmsId);

        //    string url = "https://smsplus.sslwireless.com/api/v3/send-sms";
        //    var data = new FormUrlEncodedContent(requestInput);
        //    var httpResponse = await client.PostAsync(url, data);
        //    if (httpResponse.Content != null)
        //    {
        //        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        //        dynamic response = JObject.Parse(responseContent);
        //        return new SmsResponse
        //        {
        //            status = response.status,
        //            status_code = response.status_code,
        //            error_message = response.error_message,
        //            smsinfo = response.smsinfo?.ToObject<List<SmsInfo>>()
        //            //JsonConvert.DeserializeObject<List<SmsInfo>>(response.smsinfo)
        //            //response.smsinfo?.ToObject<string[]>()
        //        };
        //    }
        //    return new SmsResponse();
        //}

        //[DontWrapResult]
        public async Task<SmsResponseDto> SendSmsNotification(SmsRequestParamDto input)
        {
            HttpClient client = new HttpClient();
            var requestInput = new Dictionary<string, string>
            {
                { "api_token", "pnij27vt-wixyw8qu-a4rwdexc-kqvpgude-tt32mdiv" },
                { "sid", "PWDNONAPI" }
            };

            requestInput.Add("msisdn", input.Msisdn);
            requestInput.Add("sms", input.Sms);
            requestInput.Add("csms_id", input.CsmsId);

            string url = "https://smsplus.sslwireless.com/api/v3/send-sms";
            var data = new FormUrlEncodedContent(requestInput);
            var httpResponse = await client.PostAsync(url, data);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                dynamic response = JObject.Parse(responseContent);
                return new SmsResponseDto
                {
                    status = response.status,
                    status_code = response.status_code,
                    error_message = response.error_message,
                    smsinfo = response.smsinfo.ToObject<List<SmsInfo>>()
                    //JsonConvert.DeserializeObject<List<SmsInfo>>(response.smsinfo)
                    //response.smsinfo?.ToObject<string[]>()
                };
            }
            return new SmsResponseDto();
        }

        //public async Task<SmsResponseDto> SendSmsTestAlpha(SmsRequestParamDto input)
        //{
        //    HttpClient client = new HttpClient();
        //    var requestInput = new Dictionary<string, string>
        //    {
        //        //{ "api_key_1", "u2AE4IjCC87Z7vDfMnSO8r5b147V4fQYD9055hkP" }
        //        { "api_key", "g694IRVD6e72jw2bBT1NKqgJfn6Af03Y68YtXMIe" }
        //    };

        //    requestInput.Add("msg", input.Sms);
        //    requestInput.Add("to", input.CsmsId);
        //    //requestInput.Add("schedule", DateTime.Now.ToString());

        //    string url = "https://api.sms.net.bd/sendsms";
        //    var data = new FormUrlEncodedContent(requestInput);
        //    var httpResponse = await client.PostAsync(url, data);
        //    if (httpResponse.Content != null)
        //    {
        //        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        //        dynamic response = JObject.Parse(responseContent);
        //        return new SmsResponseDto
        //        {
        //            status = response.data.request_status,
        //            //status_code = response.status_code,
        //            error_message = response.error,
        //            //smsinfo = response.smsinfo?.ToObject<List<SmsInfo>>()
        //            //JsonConvert.DeserializeObject<List<SmsInfo>>(response.smsinfo)
        //            //response.smsinfo?.ToObject<string[]>()
        //        };
        //    }
        //    return new SmsResponseDto();
        //}

        // GreenWeb SMS

        public async Task<SmsResponseDto> SendSmsGreenWeb(SmsRequestParamDto input)
        {
            string result = "";
            //HttpClient client = new HttpClient();
            WebRequest request = null;
            HttpWebResponse response = null;

            String to = input.Msisdn; //Recipient Phone Number multiple number must be separated by comma
            String token = "930215042016799942603064c6b63203838ad38b8f0fc7fcc9cd"; //generate token from the control panel
            String message = input.Sms; //do not use single quotation (') in the message to avoid forbidden result

            string url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;

            request = WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            if (response != null)
            {
                return new SmsResponseDto
                {
                    status = response.StatusDescription,
                    status_code = response.StatusCode.ToString(),
                };
            }
            return new SmsResponseDto();
        }

        #region Notification related functioins

        //        public async Task CreateAsync(NotificationDto input)
        //        {
        //            var response = await _httpClient.PostAsJsonAsync(CmsCommonConsts.NotificationUrl, input);
        //            if (response != null && response.IsSuccessStatusCode)
        //            {
        //                _logger.LogInformation($"Notification pushed successfuly for user : {input.CreatedBy} ");
        //            }
        //            else
        //            {
        //                _logger.LogError($"Notification pushed failed for user : {input.CreatedBy} ");
        //            }
        //        }

        private static HttpClient CreateClient()
        {
            Uri baseAddress = null;
#if DEBUG
            baseAddress = new Uri("https://localhost:44379/");
#else
                    baseAddress = new Uri("https://erpapi.mis1pwd.com/");; 
#endif
            var client = new HttpClient
            {
                BaseAddress = baseAddress
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        //        public async Task<IEnumerable<NotificationDto>> GetListAsync()
        //        {
        //            var response = await _httpClient.GetFromJsonAsync<IEnumerable<NotificationDto>>(CmsCommonConsts.NotificationUrl);
        //            return response;
        //        }

        //        public async Task<IEnumerable<NotificationDto>> GetListByClientIdAsync(string clientId, int maxRecord = 10)
        //        {
        //            var response = await _httpClient.GetFromJsonAsync<IEnumerable<NotificationDto>>(CmsCommonConsts.NotificationUrl + $"{clientId}/{maxRecord}");
        //            return response;
        //        }

        //        public async Task DeleteAsync(Guid id)
        //        {
        //            var response = await _httpClient.DeleteAsync(CmsCommonConsts.NotificationUrl + $"{id}");
        //            if (response != null && response.IsSuccessStatusCode)
        //            {
        //                _logger.LogInformation($"Notification deleted successfuly for id : {id} ");
        //            }
        //            else
        //            {
        //                _logger.LogError($"Notification delete failed for id : {id} ");
        //            }
        //        }
        //        public NotificationDto ConvertToNotification(NotificaitonCommonDto input)
        //        {
        //            var noficationInputDto = new NotificationDto
        //            {
        //                Id = GuidGenerator.Create(),
        //                ClientId = CmsCommonConsts.ClientId,
        //                Message = input.Message,
        //                CreatedBy = input.CreatedBy,
        //                CreatedFor = input.CreatedFor,
        //                CreatedAt = DateTime.Now,
        //                CreatorName = string.IsNullOrEmpty(input.CreatorName) ? "" : input.CreatorName,
        //                ReceiverName = string.IsNullOrEmpty(input.ReceiverName) ? "" : input.ReceiverName,
        //                Source = input.Source,
        //                Destination = input.Destination,
        //                Priority = input.Priority,
        //                Status = input.Status,
        //                ResourceUrl = CmsCommonConsts.ResourceUrl,
        //                Unread = true
        //            };

        //            return noficationInputDto;
        //        }

        #endregion
    }
}

