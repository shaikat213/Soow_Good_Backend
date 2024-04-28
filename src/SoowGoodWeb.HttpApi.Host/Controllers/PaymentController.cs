using Microsoft.AspNetCore.Mvc;
using SoowGoodWeb.SslCommerzData;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System;
using Volo.Abp.AspNetCore.Mvc;
using SoowGoodWeb.Interfaces;
using Newtonsoft.Json;

namespace SoowGoodWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [IgnoreAntiforgeryToken]
    public class PaymentController : AbpController
    {
        private readonly ISslCommerzService _sslCommerzAppService;
        private readonly IEkPayService _ekPayAppService;
        private readonly SslCommerzGatewayConfiguration _configuration;

        public PaymentController(ISslCommerzService sslCommerzAppService,
            IEkPayService ekPayAppService,
                                    SslCommerzGatewayConfiguration configuration)
        {
            _sslCommerzAppService = sslCommerzAppService;
            _ekPayAppService = ekPayAppService;
            _configuration = configuration;
        }

        /// <summary>
        /// SSLCOMMERZ LIVE
        /// </summary>
        /// <returns></returns>
        [HttpPost]//, ActionName("PaymentSuccess")]
        [Route("/api/services/payment-success")]
        public async Task<IActionResult> SuccessPaymentAsync()
        {
            await CompletePaymentProcess();

            return new RedirectResult(_configuration.ProdSuccessClientUrl);
        }

        [HttpPost]//, ActionName("PaymentFailed")]
        [Route("/api/services/payment-fail")]
        public async Task<IActionResult> FailedPaymentAsync()
        {
            await UpdatePaymentHistory();

            return new RedirectResult(_configuration.ProdFailClientUrl);
        }

        [HttpPost]//, ActionName("PaymentCancelled")]
        [Route("/api/services/payment-cancel")]
        public async Task<IActionResult> CancelledPaymentAsync()
        {
            await UpdatePaymentHistory();

            return new RedirectResult(_configuration.ProdCancelClientUrl);
        }

        //****************SSLCOMMERZ LIVE*************//


        /// <summary>
        /// SSLCOMMERZ SANDBOX
        /// </summary>
        /// <returns></returns>
        [HttpPost]//, ActionName("TestPaymentSuccess")]
        [Route("/api/services/test/payment-success")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> SuccessTestPaymentAsync()
        {
            await CompleteTestPaymentProcess();

            return new RedirectResult(_configuration.DevSuccessClientUrl);
        }

        [HttpPost]//, ActionName("TestPaymentFailed")]
        [Route("/api/services/test/payment-fail")]
        public async Task<IActionResult> FailedTestPaymentAsync()
        {
            await UpdatePaymentHistory();

            return new RedirectResult(_configuration.DevFailClientUrl);
        }

        [HttpPost]//, ActionName("TestPaymentCancelled")]
        [Route("/api/services/test/payment-cancel")]
        public async Task<IActionResult> CancelledTestPaymentAsync()
        {
            await UpdatePaymentHistory();

            return new RedirectResult(_configuration.DevCancelClientUrl);
        }

        [HttpPost]//, ActionName("TestPaymentSuccess")]
        [Route("/api/test/ipn")]
        //[DisableRequestSizeLimit]
        public async Task<IActionResult> SuccessTestIPNPaymentAsync()
        {
            await CompleteTestPaymentProcess();

            return new RedirectResult(_configuration.DevSuccessClientUrl);
        }
        //****************SSLCOMMERZ SANDBOX*************//

        private async Task CompletePaymentProcess(bool continueWithValidationCheck = false)
        {
            try
            {
                var sslCommerzResponseDic = await MapSslCommerzResponse();

                if (continueWithValidationCheck)
                {
                    var validationResult = await _sslCommerzAppService.ValidateTransactionAsync(sslCommerzResponseDic);

                    if ((bool)validationResult.IsValidTransaction)
                    {
                        await _sslCommerzAppService.UpdatePaymentHistory(sslCommerzResponseDic);

                        await _sslCommerzAppService.UpdateApplicantPaymentStatus(sslCommerzResponseDic);
                    }
                    else
                    {
                        Console.WriteLine($"Transaction Validation Status: {validationResult.Message}");
                    }
                }
                else
                {
                    await _sslCommerzAppService.UpdatePaymentHistory(sslCommerzResponseDic);

                    await _sslCommerzAppService.UpdateApplicantPaymentStatus(sslCommerzResponseDic);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private async Task CompleteTestPaymentProcess(bool continueWithValidationCheck = false)
        {
            try
            {
                var sslCommerzResponseDic = await MapSslCommerzResponse();

                if (continueWithValidationCheck)
                {
                    var validationResult = await _sslCommerzAppService.ValidateTestTransactionAsync(sslCommerzResponseDic);

                    if ((bool)validationResult.IsValidTransaction)
                    {
                        await _sslCommerzAppService.UpdatePaymentHistory(sslCommerzResponseDic);

                        await _sslCommerzAppService.UpdateApplicantPaymentStatus(sslCommerzResponseDic);
                    }
                    else
                    {
                        Console.WriteLine($"Transaction Validation Status: {validationResult.Message}");
                    }
                }
                else
                {
                    await _sslCommerzAppService.UpdatePaymentHistory(sslCommerzResponseDic);

                    await _sslCommerzAppService.UpdateApplicantPaymentStatus(sslCommerzResponseDic);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private async Task UpdatePaymentHistory()
        {
            try
            {
                var sslCommerzResponseDic = await MapSslCommerzResponse();

                await _sslCommerzAppService.UpdatePaymentHistory(sslCommerzResponseDic);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private async Task<Dictionary<string, string>> MapSslCommerzResponse()
        {
            var sslCommerzResponseDic = new Dictionary<string, string>();
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var result = await reader.ReadToEndAsync();
                if (!string.IsNullOrWhiteSpace(result))
                {
                    var keyValuePairs = result.Split('&');
                    foreach (var keyValuePair in keyValuePairs)
                    {
                        var keyValues = keyValuePair.Split('=');
                        if (!sslCommerzResponseDic.ContainsKey(keyValues[0]))
                        {
                            sslCommerzResponseDic.Add(keyValues[0], keyValues[1]);
                        }
                    }
                }
            }

            return sslCommerzResponseDic;
        }
    }
}
