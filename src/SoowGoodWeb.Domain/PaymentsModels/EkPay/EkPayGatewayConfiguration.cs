using Microsoft.Extensions.Configuration;
using SoowGoodWeb.PaymentsModels;
using System;

namespace SoowGoodWeb.EkPayData
{
    public class EkPayGatewayConfiguration : IPaymentGatewayConfiguration
    {
        private readonly IConfiguration _appConfiguration;

        public EkPayGatewayConfiguration(IConfiguration configurationAccessor)
        {
            _appConfiguration = configurationAccessor;
        }

        public bool IsActive => _appConfiguration["Payment:EkPay:IsActive"].To<bool>();
        public string SubmitUrl => _appConfiguration["Payment:EkPay:SubmitUrl"];
        //public string ValidationUrl => _appConfiguration["Payment:EkPay:DevIpnLintener"];
        //public string CheckingUrl => _appConfiguration["Payment:EkPay:CheckingUrl"];

        // Sandbox or Test
        public string SandboxEnvironment => _appConfiguration["Payment:EkPay:SandboxEnvironment"];
        public string SandboxStoreId => _appConfiguration["Payment:EkPay:SandboxStoreId"];
        public string SandboxStorePassword => _appConfiguration["Payment:EkPay:SandboxStorePassword"];
        public string SanboxUrl => _appConfiguration["Payment:EkPay:SanboxUrl"];
        public string SandboxSubmitUrl => SanboxUrl + SubmitUrl;
        //public string SandboxValidationUrl => SanboxUrl + ValidationUrl;
        //public string SandboxCheckingUrl => SanboxUrl + CheckingUrl;

        //// Live or Prod
        public string LiveEnvironment => _appConfiguration["Payment:EkPay:LiveEnvironment"];
        public string LiveStoreId => _appConfiguration["Payment:EkPay:LiveStoreId"];
        public string LiveStorePassword => _appConfiguration["Payment:EkPay:LiveStorePassword"];
        public string LiveUrl => _appConfiguration["Payment:EkPay:LiveUrl"];
        public string LiveSubmitUrl => LiveUrl + SubmitUrl;
        //public string LiveValidationUrl => LiveUrl + ValidationUrl;
        //public string LiveCheckingUrl => LiveUrl + CheckingUrl;

        // Success, Fail or Cancel Callback Url
        public string DevSuccessCallbackUrl => _appConfiguration["Payment:EkPay:DevSuccessCallbackUrl"];
        public string DevFailCallbackUrl => _appConfiguration["Payment:EkPay:DevFailCallbackUrl"];
        public string DevCancelCallbackUrl => _appConfiguration["Payment:EkPay:DevCancelCallbackUrl"];
        public string DevIpnLintener => _appConfiguration["Payment:EkPay:DevIpnLintener"];

        public string ProdSuccessCallbackUrl => _appConfiguration["Payment:EkPay:ProdSuccessCallbackUrl"];
        public string ProdFailCallbackUrl => _appConfiguration["Payment:EkPay:ProdFailCallbackUrl"];
        public string ProdCancelCallbackUrl => _appConfiguration["Payment:EkPay:ProdCancelCallbackUrl"];
        public string ProdIpnLintener => _appConfiguration["Payment:EkPay:ProdIpnLintener"];

        //// Success, Fail or Cancel Client Url
        public string DevSuccessClientUrl => _appConfiguration["Payment:EkPay:DevSuccessClientUrl"];
        public string DevFailClientUrl => _appConfiguration["Payment:EkPay:DevFailClientUrl"];
        public string DevCancelClientUrl => _appConfiguration["Payment:EkPay:DevCancelClientUrl"];

        public string ProdSuccessClientUrl => _appConfiguration["Payment:EkPay:ProdSuccessClientUrl"];
        public string ProdFailClientUrl => _appConfiguration["Payment:EkPay:ProdFailClientUrl"];
        public string ProdCancelClientUrl => _appConfiguration["Payment:EkPay:ProdCancelClientUrl"];
    }
}