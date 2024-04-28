using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoowGoodWeb.NagadData
{
    public class NagadPaymentResponse
    {
        public string MerchantId { get; set; }
        public string OrderId { get; set; }
        public string PaymentRefId { get; set; }
        public string Amount { get; set; }
        public string ClientMobileNo { get; set; }
        public string MerchantMobileNo { get; set; }
        public string OrderDateTime { get; set; }
        public string IssuerPaymentDateTime { get; set; }
        public string IssuerPaymentReferenceNo { get; set; }
        public Object AdditionalMerchantInfo { get; set; }
        public NagadPaymentStatus Status { get; set; }
        public string StatusCode { get; set; }
    }

    public enum NagadPaymentStatus
    {
        Success,
        OrderInitiated,
        Ready,
        InProgress,
        Cancelled,
        InvalidRequest,
        Fraud,
        Aborted,
        UnknownFailed
    }
}