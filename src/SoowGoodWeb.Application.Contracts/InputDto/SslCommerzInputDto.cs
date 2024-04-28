namespace SoowGoodWeb.InputDto
{
    public class SslCommerzInputDto
    {
        public string? ApplicationCode { get; set; }
        public string? TransactionId { get; set; }
        public string? TotalAmount { get; set; }
    }

    public class PaymentHistoryMobileInputDto
    {
        public string? ApplicationCode { get; set; }
        public string? TransactionId { get; set; }
        public string? TotalAmount { get; set; }
        public string? SessionKey { get; set; }
        public string? Status { get; set; }
        public string? FailedReason { get; set; }
    }
}
