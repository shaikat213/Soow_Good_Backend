using Microsoft.Extensions.Configuration;
using SoowGoodWeb.PaymentsModels;
using System;

namespace SoowGoodWeb.SslCommerzData
{
    public class SslCommerzGatewayConfiguration : IPaymentGatewayConfiguration
    {
        private readonly IConfiguration _appConfiguration;

        public SslCommerzGatewayConfiguration(IConfiguration configurationAccessor)
        {
            _appConfiguration = configurationAccessor;
        }

        public bool IsActive => _appConfiguration["Payment:SslCommerz:IsActive"].To<bool>();
        public string SubmitUrl => _appConfiguration["Payment:SslCommerz:SubmitUrl"];
        public string ValidationUrl => _appConfiguration["Payment:SslCommerz:ValidationUrl"];
        public string CheckingUrl => _appConfiguration["Payment:SslCommerz:CheckingUrl"];

        // Sandbox or Test
        public string SandboxEnvironment => _appConfiguration["Payment:SslCommerz:SandboxEnvironment"];
        public string SandboxStoreId => _appConfiguration["Payment:SslCommerz:SandboxStoreId"];
        public string SandboxStorePassword => _appConfiguration["Payment:SslCommerz:SandboxStorePassword"];
        public string SanboxUrl => _appConfiguration["Payment:SslCommerz:SanboxUrl"];
        public string SandboxSubmitUrl => SanboxUrl + SubmitUrl;
        public string SandboxValidationUrl => SanboxUrl + ValidationUrl;
        public string SandboxCheckingUrl => SanboxUrl + CheckingUrl;

        // Live or Prod
        public string LiveEnvironment => _appConfiguration["Payment:SslCommerz:LiveEnvironment"];
        public string LiveStoreId => _appConfiguration["Payment:SslCommerz:LiveStoreId"];
        public string LiveStorePassword => _appConfiguration["Payment:SslCommerz:LiveStorePassword"];
        public string LiveUrl => _appConfiguration["Payment:SslCommerz:LiveUrl"];
        public string LiveSubmitUrl => LiveUrl + SubmitUrl;
        public string LiveValidationUrl => LiveUrl + ValidationUrl;
        public string LiveCheckingUrl => LiveUrl + CheckingUrl;

        // Success, Fail or Cancel Callback Url
        public string DevSuccessCallbackUrl => _appConfiguration["Payment:SslCommerz:DevSuccessCallbackUrl"];
        public string DevFailCallbackUrl => _appConfiguration["Payment:SslCommerz:DevFailCallbackUrl"];
        public string DevCancelCallbackUrl => _appConfiguration["Payment:SslCommerz:DevCancelCallbackUrl"];
        public string DevIpnLintener => _appConfiguration["Payment:SslCommerz:DevIpnLintener"];

        public string ProdSuccessCallbackUrl => _appConfiguration["Payment:SslCommerz:ProdSuccessCallbackUrl"];
        public string ProdFailCallbackUrl => _appConfiguration["Payment:SslCommerz:ProdFailCallbackUrl"];
        public string ProdCancelCallbackUrl => _appConfiguration["Payment:SslCommerz:ProdCancelCallbackUrl"];
        public string ProdIpnLintener => _appConfiguration["Payment:SslCommerz:ProdIpnLintener"];

        // Success, Fail or Cancel Client Url
        public string DevSuccessClientUrl => _appConfiguration["Payment:SslCommerz:DevSuccessClientUrl"];
        public string DevFailClientUrl => _appConfiguration["Payment:SslCommerz:DevFailClientUrl"];
        public string DevCancelClientUrl => _appConfiguration["Payment:SslCommerz:DevCancelClientUrl"];

        public string ProdSuccessClientUrl => _appConfiguration["Payment:SslCommerz:ProdSuccessClientUrl"];
        public string ProdFailClientUrl => _appConfiguration["Payment:SslCommerz:ProdFailClientUrl"];
        public string ProdCancelClientUrl => _appConfiguration["Payment:SslCommerz:ProdCancelClientUrl"];
    }
}