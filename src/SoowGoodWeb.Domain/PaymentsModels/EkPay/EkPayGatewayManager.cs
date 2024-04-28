using System;
using Nancy.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp.DependencyInjection;
using SoowGoodWeb.EkPayData;
using Newtonsoft.Json;
using SoowGoodWeb.DtoModels;
using System.Net.Http;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SoowGoodWeb.EkPayData
{
    public class EkPayGatewayManager :  ITransientDependency
    {
        private readonly EkPayGatewayConfiguration _configuration;

        public EkPayGatewayManager(EkPayGatewayConfiguration configuration)
        {
            _configuration = configuration;
        }

        ///***** For Live Transactions ****///
        
        //public bool IsValidateStore()
        //{
        //    if (string.IsNullOrWhiteSpace(_configuration.LiveStoreId))
        //    {
        //        throw new Exception("Please provide Store ID to initialize SSLCommerz");
        //    }

        //    if (string.IsNullOrWhiteSpace(_configuration.LiveStorePassword))
        //    {
        //        throw new Exception("Please provide Store Password to initialize SSLCommerz");
        //    }

        //    return true;
        //}
        //public async Task<SSLCommerzInitResponse> InitiatePaymentAsync(NameValueCollection postData)
        //{
        //    var initResponse = new SSLCommerzInitResponse();
        //    try
        //    {
        //        var response = await SendPaymentRequestAsync(_configuration.LiveSubmitUrl, postData);
        //        initResponse = new JavaScriptSerializer().Deserialize<SSLCommerzInitResponse>(response);
        //        return initResponse;
        //    }
        //    catch (Exception e)
        //    {
        //        var jsonResponse = JsonConvert.SerializeObject(initResponse);
        //        var jsonPostData = JsonConvert.SerializeObject(postData.ToDictionary());
        //        throw new Exception($"InitResponse: {jsonResponse} {Environment.NewLine}- PostData: {jsonPostData} {Environment.NewLine}- ErrorMsg: {e.Message}");
        //    }
        //}
        //public async Task<TransactionValidationDto> ValidateTransactionAsync(Dictionary<string, string> responseDic)
        //{
        //    return await Task.Run(() =>
        //    {
        //        string message;
        //        bool isValidTransaction;

        //        var hashVerified = IpnHashVerify(responseDic, _configuration.LiveStorePassword);
        //        if (hashVerified)
        //        {
        //            responseDic.TryGetValue("val_id", out string valId);
        //            var encodedValId = HttpUtility.UrlEncode(valId);
        //            var encodedStoreId = HttpUtility.UrlEncode(_configuration.LiveStoreId);
        //            var encodedStorePassword = HttpUtility.UrlEncode(_configuration.LiveStorePassword);

        //            var validateUrl = _configuration.LiveValidationUrl + "?val_id=" + encodedValId + "&store_id=" + encodedStoreId + "&store_passwd=" + encodedStorePassword + "&v=1&format=json";

        //            var request = (HttpWebRequest)WebRequest.Create(validateUrl);
        //            var response = (HttpWebResponse)request.GetResponse();
        //            var responseStream = response.GetResponseStream();

        //            var jsonResponse = string.Empty;
        //            using (StreamReader reader = new StreamReader(responseStream))
        //            {
        //                jsonResponse = reader.ReadToEnd();
        //            }

        //            if (!string.IsNullOrWhiteSpace(jsonResponse))
        //            {
        //                var validationResponse = new JavaScriptSerializer().Deserialize<SSLCommerzValidatorResponse>(jsonResponse);

        //                if (validationResponse.status == "VALID" || validationResponse.status == "VALIDATED")
        //                {
        //                    responseDic.TryGetValue("tran_id", out string merchantTrxId);
        //                    responseDic.TryGetValue("amount", out string merchantTrxAmount);
        //                    responseDic.TryGetValue("currency", out string merchantTrxCurrency);

        //                    if (!string.IsNullOrWhiteSpace(merchantTrxCurrency) && merchantTrxCurrency.Equals("BDT", StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        if (merchantTrxId == validationResponse.tran_id && (Math.Abs(Convert.ToDecimal(merchantTrxAmount) - Convert.ToDecimal(validationResponse.amount)) < 1))
        //                        {
        //                            isValidTransaction = true;
        //                            message = "Amount mached!";
        //                        }
        //                        else
        //                        {
        //                            isValidTransaction = false;
        //                            message = "Amount not matching!";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (merchantTrxId == validationResponse.tran_id && (Math.Abs(Convert.ToDecimal(merchantTrxAmount) - Convert.ToDecimal(validationResponse.currency_amount)) < 1) && merchantTrxCurrency == validationResponse.currency_type)
        //                        {
        //                            isValidTransaction = true;
        //                            message = "Currency amount matched";
        //                        }
        //                        else
        //                        {
        //                            isValidTransaction = false;
        //                            message = "Currency amount not matching";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    isValidTransaction = false;
        //                    message = "This transaction is either expired or fails";
        //                }
        //            }
        //            else
        //            {
        //                isValidTransaction = false;
        //                message = "Unable to get transaction JSON status";
        //            }
        //        }
        //        else
        //        {
        //            isValidTransaction = false;
        //            message = "Unable to verify hash";
        //        }

        //        return new TransactionValidationDto
        //        {
        //            Message = message,
        //            IsValidTransaction = isValidTransaction
        //        };
        //    });
        //}
        //public Task<bool> InitiateRefundAsync()
        //{
        //    throw new NotImplementedException();
        //}
        //public NameValueCollection CreatePostData(SslCommerzPostDataDto postDataDto)
        //{
        //    var postData = new NameValueCollection
        //    {
        //        { "store_id", _configuration.LiveStoreId },
        //        { "store_passwd", _configuration.LiveStorePassword },
        //        { "total_amount", $"{postDataDto.total_amount}" },
        //        { "currency", $"{postDataDto.currency}" },
        //        { "tran_id", $"{postDataDto.tran_id}" },
        //        { "success_url", _configuration.ProdSuccessCallbackUrl },
        //        { "fail_url", _configuration.ProdFailCallbackUrl },
        //        { "cancel_url", _configuration.ProdCancelCallbackUrl },
        //        { "ipn_url", _configuration.ProdIpnLintener },
        //        { "cus_name", $"{postDataDto.cus_name}" },
        //        { "cus_email", $"{postDataDto.cus_email}" },
        //        { "cus_add1", $"{postDataDto.cus_add1}" },
        //        { "cus_add2", $"{postDataDto.cus_add2}" },
        //        { "cus_city", $"{postDataDto.cus_city}"  },
        //        { "cus_state", $"{postDataDto.cus_state}" },
        //        { "cus_postcode", $"{postDataDto.cus_postcode}" },
        //        { "cus_country", $"{postDataDto.cus_country}" },
        //        { "cus_phone", $"{postDataDto.cus_phone}" },
        //        { "cus_fax", $"{postDataDto.cus_fax}" },
        //        { "ship_name", $"{postDataDto.ship_name}" },
        //        { "ship_add1", $"{postDataDto.ship_add1}" },
        //        { "ship_add2", $"{postDataDto.ship_add2}" },
        //        { "ship_city", $"{postDataDto.ship_city}" },
        //        { "ship_state", $"{postDataDto.ship_state}" },
        //        { "ship_postcode", $"{postDataDto.ship_postcode}" },
        //        { "ship_country", $"{postDataDto.ship_country}" },
        //        { "value_a", $"{postDataDto.value_a}" },
        //        { "value_b", $"{postDataDto.value_b}" },
        //        { "value_c", $"{postDataDto.value_c}" },
        //        { "value_d", $"{postDataDto.value_d}" },
        //        { "shipping_method", $"{postDataDto.shipping_method}" },
        //        { "num_of_item", $"{postDataDto.num_of_item}" },
        //        { "product_name", $"{postDataDto.product_name}" },
        //        { "product_profile", $"{postDataDto.product_profile}" },
        //        { "product_category", $"{postDataDto.product_category}" }
        //    };

        //    return postData;
        //}
        ///////

        /***///////////// For Sandbox //////*////
        
        public bool IsValidateTestStore()
        {
            if (string.IsNullOrWhiteSpace(_configuration.SandboxStoreId))
            {
                throw new Exception("Please provide Store ID to initialize SSLCommerz");
            }

            if (string.IsNullOrWhiteSpace(_configuration.SandboxStorePassword))
            {
                throw new Exception("Please provide Store Password to initialize SSLCommerz");
            }

            return true;
        }

        public async Task<EkPayTokenResponse> InitiatePaymentAsync(data_raw postData)
        {
            var initResponse = new EkPayTokenResponse();
            try
            {
                string response = await SendPaymentRequestAsync(_configuration.LiveSubmitUrl, postData);
                initResponse = new JavaScriptSerializer().Deserialize<EkPayTokenResponse>(response);
                return initResponse;
            }
            catch (Exception e)
            {
                var jsonResponse = JsonConvert.SerializeObject(initResponse);
                var jsonPostData = JsonConvert.SerializeObject(postData);
                throw new Exception($"InitResponse: {jsonResponse} {Environment.NewLine}- PostData: {jsonPostData} {Environment.NewLine}- ErrorMsg: {e.Message}");
            }
        }

        public async Task<EkPayTokenResponse> InitiateTestPaymentAsync(data_raw postData)
        {
            var initResponse = new EkPayTokenResponse();
            try
            {
                string response = await SendPaymentRequestAsync(_configuration.SandboxSubmitUrl, postData);
                initResponse = new JavaScriptSerializer().Deserialize<EkPayTokenResponse>(response);
                return initResponse;
            }
            catch (Exception e)
            {
                var jsonResponse = JsonConvert.SerializeObject(initResponse);
                var jsonPostData = JsonConvert.SerializeObject(postData);
                throw new Exception($"InitResponse: {jsonResponse} {Environment.NewLine}- PostData: {jsonPostData} {Environment.NewLine}- ErrorMsg: {e.Message}");
            }
        }

        //public async Task<TransactionValidationDto> ValidateTestTransactionAsync(Dictionary<string, string> responseDic)
        //{
        //    return await Task.Run(() =>
        //    {
        //        string message;
        //        bool isValidTransaction;

        //        var hashVerified = IpnHashVerify(responseDic, _configuration.SandboxStorePassword);
        //        if (hashVerified)
        //        {
        //            responseDic.TryGetValue("val_id", out string valId);
        //            var encodedValId = HttpUtility.UrlEncode(valId);
        //            var encodedStoreId = HttpUtility.UrlEncode(_configuration.SandboxStoreId);
        //            var encodedStorePassword = HttpUtility.UrlEncode(_configuration.SandboxStorePassword);

        //            var validateUrl = _configuration.ValidationUrl + "?val_id=" + encodedValId + "&store_id=" + encodedStoreId + "&store_passwd=" + encodedStorePassword + "&v=1&format=json";

        //            var request = (HttpWebRequest)WebRequest.Create(validateUrl);
        //            var response = (HttpWebResponse)request.GetResponse();
        //            var responseStream = response.GetResponseStream();

        //            var jsonResponse = string.Empty;
        //            using (StreamReader reader = new StreamReader(responseStream))
        //            {
        //                jsonResponse = reader.ReadToEnd();
        //            }

        //            if (!string.IsNullOrWhiteSpace(jsonResponse))
        //            {
        //                var validationResponse = new JavaScriptSerializer().Deserialize<SSLCommerzValidatorResponse>(jsonResponse);

        //                if (validationResponse.status == "VALID" || validationResponse.status == "VALIDATED")
        //                {
        //                    responseDic.TryGetValue("tran_id", out string merchantTrxId);
        //                    responseDic.TryGetValue("amount", out string merchantTrxAmount);
        //                    responseDic.TryGetValue("currency", out string merchantTrxCurrency);

        //                    if (!string.IsNullOrWhiteSpace(merchantTrxCurrency) && merchantTrxCurrency.Equals("BDT", StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        if (merchantTrxId == validationResponse.tran_id && (Math.Abs(Convert.ToDecimal(merchantTrxAmount) - Convert.ToDecimal(validationResponse.amount)) < 1))
        //                        {
        //                            isValidTransaction = true;
        //                            message = "Amount mached!";
        //                        }
        //                        else
        //                        {
        //                            isValidTransaction = false;
        //                            message = "Amount not matching!";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (merchantTrxId == validationResponse.tran_id && (Math.Abs(Convert.ToDecimal(merchantTrxAmount) - Convert.ToDecimal(validationResponse.currency_amount)) < 1) && merchantTrxCurrency == validationResponse.currency_type)
        //                        {
        //                            isValidTransaction = true;
        //                            message = "Currency amount matched";
        //                        }
        //                        else
        //                        {
        //                            isValidTransaction = false;
        //                            message = "Currency amount not matching";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    isValidTransaction = false;
        //                    message = "This transaction is either expired or fails";
        //                }
        //            }
        //            else
        //            {
        //                isValidTransaction = false;
        //                message = "Unable to get Transaction JSON status";
        //            }
        //        }
        //        else
        //        {
        //            isValidTransaction = false;
        //            message = "Unable to verify hash";
        //        }

        //        return new TransactionValidationDto
        //        {
        //            Message = message,
        //            IsValidTransaction = isValidTransaction
        //        };
        //    });
        //}

        public Task<bool> InitiateTestRefundAsync()
        {
            throw new NotImplementedException();
        }

        //public NameValueCollection CreateTestPostData(EkPayPostDataDto postDataDto)
        //{
        //    var postData = new NameValueCollection
        //    {
        //        { "store_id", _configuration.SandboxStoreId },
        //        { "store_passwd", _configuration.SandboxStorePassword },
        //        { "total_amount", $"{postDataDto.total_amount}" },
        //        { "currency", $"{postDataDto.currency}" },
        //        { "tran_id", $"{postDataDto.tran_id}" },
        //        { "success_url", _configuration.DevSuccessCallbackUrl},
        //        { "fail_url", _configuration.DevFailCallbackUrl },
        //        { "cancel_url", _configuration.DevCancelCallbackUrl },
        //        //{ "ipn_url", _configuration.DevIpnLintener },
        //        { "cus_name", $"{postDataDto.cus_name}" },
        //        { "cus_email", $"{postDataDto.cus_email}" },
        //        { "cus_add1", $"{postDataDto.cus_add1}" },
        //        { "cus_add2", $"{postDataDto.cus_add2}" },
        //        { "cus_city", $"{postDataDto.cus_city}"  },
        //        { "cus_state", $"{postDataDto.cus_state}" },
        //        { "cus_postcode", $"{postDataDto.cus_postcode}" },
        //        { "cus_country", $"{postDataDto.cus_country}" },
        //        { "cus_phone", $"{postDataDto.cus_phone}" },
        //        { "cus_fax", $"{postDataDto.cus_fax}" },
        //        { "ship_name", $"{postDataDto.ship_name}" },
        //        { "ship_add1", $"{postDataDto.ship_add1}" },
        //        { "ship_add2", $"{postDataDto.ship_add2}" },
        //        { "ship_city", $"{postDataDto.ship_city}" },
        //        { "ship_state", $"{postDataDto.ship_state}" },
        //        { "ship_postcode", $"{postDataDto.ship_postcode}" },
        //        { "ship_country", $"{postDataDto.ship_country}" },
        //        { "value_a", $"{postDataDto.value_a}" },
        //        { "value_b", $"{postDataDto.value_b}" },
        //        { "value_c", $"{postDataDto.value_c}" },
        //        { "value_d", $"{postDataDto.value_d}" },
        //        { "shipping_method", $"{postDataDto.shipping_method}" },
        //        { "num_of_item", $"{postDataDto.num_of_item}" },
        //        { "product_name", $"{postDataDto.product_name}" },
        //        { "product_profile", $"{postDataDto.product_profile}" },
        //        { "product_category", $"{postDataDto.product_category}" }
        //    };

        //    return postData;
        //}

        //public async Task<EkPayIpnResponse> InitiateTestIpnPaymentAsync(data_raw postData)
        //{
        //    var initResponse = new EkPayTokenResponse();
        //    try
        //    {
        //        string response = await SendPaymentRequestAsync(_configuration.SandboxSubmitUrl, postData);
        //        initResponse = new JavaScriptSerializer().Deserialize<EkPayTokenResponse>(response);
        //        return initResponse;
        //    }
        //    catch (Exception e)
        //    {
        //        var jsonResponse = JsonConvert.SerializeObject(initResponse);
        //        var jsonPostData = JsonConvert.SerializeObject(postData);
        //        throw new Exception($"InitResponse: {jsonResponse} {Environment.NewLine}- PostData: {jsonPostData} {Environment.NewLine}- ErrorMsg: {e.Message}");
        //    }
        //}
        public data_raw CreateDataRaw(EkPayDataRawDto postData)
        {
            var merChantInfo = new mer_info();
            merChantInfo.mer_reg_id = _configuration.LiveStoreId;
            merChantInfo.mer_pas_key = _configuration.LiveStorePassword;
            var feedUriInfo = new feed_uri();
            feedUriInfo.c_uri = _configuration.ProdCancelClientUrl;//.DevCancelCallbackUrl;
            feedUriInfo.f_uri = _configuration.ProdFailClientUrl;
            feedUriInfo.s_uri = _configuration.ProdSuccessClientUrl; //DevSuccessCallbackUrl
            var customerInfo = new cust_info();
            customerInfo.cust_email = postData.cust_email;
            customerInfo.cust_id = "";//postData.cust_id;
            customerInfo.cust_mail_addr = "Dhaka";//postData.cust_mail_addr;
            customerInfo.cust_mobo_no = postData.cust_mobo_no;
            customerInfo.cust_name = postData.cust_name;
            var trnsInfo = new trns_info();
            trnsInfo.ord_det = postData.ord_det;
            trnsInfo.ord_id = postData.ord_id;
            trnsInfo.trnx_amt = postData.trnx_amt;
            trnsInfo.trnx_currency = postData.trnx_currency;
            trnsInfo.trnx_id = postData.trnx_id;
            var ipnInfo = new ipn_info();
            ipnInfo.ipn_channel = "3";
            ipnInfo.ipn_email = "sanjida.a@coppanet.com";
            ipnInfo.ipn_uri = _configuration.ProdIpnLintener;//"https://www.dev.ekpay.gov.bd/test/ipn";
            
            var ekPayDataRaw = new data_raw();
            ekPayDataRaw.mer_info = merChantInfo;
            ekPayDataRaw.req_timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss 'GMT''+''6'");//"2024-11-08 18:14:00 GMT + 6";
            ekPayDataRaw.feed_uri = feedUriInfo;
            ekPayDataRaw.cust_info = customerInfo;
            ekPayDataRaw.trns_info = trnsInfo;
            ekPayDataRaw.ipn_info = ipnInfo;
            ekPayDataRaw.mac_addr = "103.125.253.240"; //"103.92.84.64";//"103.125.253.240";

            return ekPayDataRaw;
        }

        public data_raw CreateTestDataRaw(EkPayDataRawDto postData)
        {
            var merChantInfo = new mer_info();
            merChantInfo.mer_reg_id = _configuration.SandboxStoreId;
            merChantInfo.mer_pas_key = _configuration.SandboxStorePassword;
            var feedUriInfo = new feed_uri();
            feedUriInfo.c_uri = _configuration.DevCancelClientUrl;
            feedUriInfo.f_uri = _configuration.DevFailClientUrl;
            feedUriInfo.s_uri = _configuration.DevSuccessClientUrl;
            var customerInfo = new cust_info();
            customerInfo.cust_email = postData.cust_email;
            customerInfo.cust_id = "";
            customerInfo.cust_mail_addr = "Dhaka";
            customerInfo.cust_mobo_no = postData.cust_mobo_no;
            customerInfo.cust_name = postData.cust_name;
            var trnsInfo = new trns_info();
            trnsInfo.ord_det = postData.ord_det;
            trnsInfo.ord_id = postData.ord_id;
            trnsInfo.trnx_amt = postData.trnx_amt;
            trnsInfo.trnx_currency = postData.trnx_currency;
            trnsInfo.trnx_id = postData.trnx_id;
            var ipnInfo = new ipn_info();
            ipnInfo.ipn_channel = "1";
            ipnInfo.ipn_email = "sanjida.a@coppanet.com";
            ipnInfo.ipn_uri = _configuration.ProdIpnLintener;//"https://www.dev.ekpay.gov.bd/test/ipn";

            var ekPayDataRaw = new data_raw();
            ekPayDataRaw.mer_info = merChantInfo;
            ekPayDataRaw.req_timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss 'GMT''+''6'");//"2024-11-08 18:14:00 GMT + 6";
            ekPayDataRaw.feed_uri = feedUriInfo;
            ekPayDataRaw.cust_info = customerInfo;
            ekPayDataRaw.trns_info = trnsInfo;
            ekPayDataRaw.ipn_info = ipnInfo;
            ekPayDataRaw.mac_addr = "1.1.1.1";

            return ekPayDataRaw;
        }

        // Common Actions
        public async Task<string> SendPaymentRequestAsync(string url, data_raw postData)
        {
            HttpResponseMessage response = null;
            using (var client = new HttpClient())
            {
                var uploadData = JsonSerializer.Serialize(postData);
                var requestContent = new StringContent(uploadData, Encoding.UTF8, "application/json");
                response = await client.PostAsync(url, requestContent);
            }
            var str = await response.Content.ReadAsStringAsync();//Encoding.UTF8.GetString(response);
            return str;//Encoding.UTF8.GetString(response);
        }

        public bool IpnHashVerify(Dictionary<string, string> responseDic, string storePassword)
        {
            responseDic.TryGetValue("verify_sign", out string verify_sign);
            responseDic.TryGetValue("verify_key", out string verify_key);

            if (!string.IsNullOrWhiteSpace(verify_sign) && !string.IsNullOrWhiteSpace(verify_key))
            {
                var keyList = verify_key.Split("%2C");
                var dataArray = new List<KeyValuePair<string, string>>();

                foreach (var key in keyList)
                {
                    responseDic.TryGetValue(key, out string value);
                    dataArray.Add(new KeyValuePair<string, string>(key, value));
                }

                string hashedPass = this.MD5(storePassword);
                dataArray.Add(new KeyValuePair<string, string>("store_passwd", hashedPass));

                dataArray.Sort(
                    delegate (KeyValuePair<string, string> pair1,
                    KeyValuePair<string, string> pair2)
                    {
                        return pair1.Key.CompareTo(pair2.Key);
                    }
                );

                var hashString = string.Empty;
                foreach (var kv in dataArray)
                {
                    hashString += kv.Key + "=" + kv.Value + "&";
                }

                hashString = hashString.TrimEnd('&');
                var generatedHash = this.MD5(hashString);

                // Check if generated hash and verify_sign match or not
                if (generatedHash == verify_sign)
                {
                    return true; // Matched
                }
                return false; // Not Matched
            }
            else
            {
                return false;
            }
        }

        public string MD5(string s)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);
            byte[] hashedBytes = System.Security.Cryptography.MD5.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString;
        }
    }
}