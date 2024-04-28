using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using SoowGoodWeb.SslCommerz;
using SoowGoodWeb.SslCommerz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class PaymentService : SoowGoodWebAppService, ISslCommerzService
    {
        //private readonly IRepository<Appointment> _appointmentRepository;
        //private readonly IPaymentHistoryService _paymentHistoryService;
        //private readonly INotificationAppService _notificationAppService;
        //private readonly SslCommerzGatewayManager _sslCommerzGatewayManager;

        //INotificationAppService notificationAppService,
        public PaymentService(IRepository<Appointment> appointmentRepository,
                                    IPaymentHistoryService paymentHistoryService,
                                    SslCommerzGatewayManager sslCommerzGatewayManager)
        {
            //_appointmentRepository = appointmentRepository;
            //_paymentHistoryService = paymentHistoryService;
            //_notificationAppService = notificationAppService;
            //_sslCommerzGatewayManager = sslCommerzGatewayManager;
        }


        //[HttpPost]
        public async Task<SslCommerzInitDto> InitiatePaymentAsync(SslCommerzInputDto input)
        {
            input.TransactionId = GenerateTransactionId(16);
            return new SslCommerzInitDto();

            //var applicantData = await GetApplicantDetails(input);

            //var postData = _sslCommerzGatewayManager.CreatePostData(applicantData);

            //var initResponse = await _sslCommerzGatewayManager.InitiatePaymentAsync(postData);

            //await InitPaymentHistory(input, initResponse);

            //return GetInitPaymentResponse(initResponse);
        }

        private async Task InitPaymentHistory(SslCommerzInputDto input, SSLCommerzInitResponse initResponse)
        {
            //await _paymentHistoryService.CreateAsync(new PaymentHistoryInputDto
            //{
            //    amount = input.TotalAmount,
            //    status = initResponse.status,
            //    tran_id = input.TransactionId,
            //    sessionkey = initResponse.sessionkey,
            //    failedreason = initResponse.failedreason,
            //    application_code = input.ApplicationCode
            //});
        }

        //[HttpGet]
        public async Task<TransactionValidationDto> ValidateTransactionAsync(Dictionary<string, string> responseDic)
        {
            return null;//await _sslCommerzGatewayManager.ValidateTransactionAsync(responseDic);
        }

        //[HttpGet]
        public async Task<bool> InitiateRefundAsync()
        {
            //var response = await Task.Run(() =>
            //{
            //    return _sslCommerzGatewayManager.InitiateRefundAsync();
            //});
            return false;// response;
        }

        //[HttpPost]
        public async Task<SslCommerzInitDto> InitiateTestPaymentAsync(SslCommerzInputDto input)
        {
            input.TransactionId = GenerateTransactionId(16);
            var nuDto = new SslCommerzInitDto();

            //var applicantData = await GetApplicantDetails(input);

            //var postData = _sslCommerzGatewayManager.CreateTestPostData(applicantData);

            //var initResponse = await _sslCommerzGatewayManager.InitiateTestPaymentAsync(postData);

            //await InitPaymentHistory(input, initResponse);

            return nuDto; //GetInitPaymentResponse(initResponse);
        }

        //[HttpGet]
        public async Task<TransactionValidationDto> ValidateTestTransactionAsync(Dictionary<string, string> responseDic)
        {
            return null; //await _sslCommerzGatewayManager.ValidateTestTransactionAsync(responseDic);
        }


        //[HttpGet]
        public async Task<bool> InitiateTestRefundAsync()
        {
            //var response = await Task.Run(() =>
            //{
            //    return _sslCommerzGatewayManager.InitiateTestRefundAsync();
            //});
            return false; // response;
        }

        private async Task<SslCommerzPostDataDto> GetApplicantDetails(SslCommerzInputDto input)
        {
            var nDto = new SslCommerzPostDataDto();
            //return await Task.Run(() =>
            //{
            //    var job = _jobApplicationRepository.GetAll()
            //                .Include(i => i.Applicant)
            //                .ThenInclude(i => i.ApplicantAddresses)
            //                .FirstOrDefault(a => a.ApplicationCode == input.ApplicationCode);

            //    var sslCommerzPostDataDto = new SslCommerzPostDataDto();
            //    if (job != null && job.ApplicationStatus == ApplicationStatus.Applied)
            //    {
            //        sslCommerzPostDataDto.tran_id = input.TransactionId;
            //        sslCommerzPostDataDto.total_amount = input.TotalAmount;
            //        sslCommerzPostDataDto.currency = "BDT";
            //        sslCommerzPostDataDto.cus_name = job.Applicant.Name;
            //        sslCommerzPostDataDto.cus_email = job.Applicant.Email;
            //        sslCommerzPostDataDto.cus_phone = job.Applicant.Mobile;

            //        var applicantAddr = job.Applicant.ApplicantAddresses.FirstOrDefault();
            //        sslCommerzPostDataDto.cus_add1 = applicantAddr?.Address;
            //        sslCommerzPostDataDto.cus_postcode = applicantAddr?.PostCode;
            //        sslCommerzPostDataDto.cus_city = applicantAddr?.District;
            //        sslCommerzPostDataDto.cus_country = "Bangladesh";
            //        sslCommerzPostDataDto.shipping_method = "NO";
            //        sslCommerzPostDataDto.num_of_item = "1";
            //        sslCommerzPostDataDto.product_name = "Application Fee";
            //        sslCommerzPostDataDto.product_profile = "PWD";
            //        sslCommerzPostDataDto.product_category = "Job Application";
            //    }

            //    return sslCommerzPostDataDto;
            //});
            return nDto;
        }

        public async Task UpdatePaymentHistory(Dictionary<string, string> sslCommerzResponseDic)
        {
            //sslCommerzResponseDic.TryGetValue("tran_id", out string tran_id);
            //if (!string.IsNullOrWhiteSpace(tran_id))
            //{
            //    var paymentHistory = await _paymentHistoryService.GetByTranIdAsync(tran_id);
            //    if (paymentHistory != null)
            //    {
            //        var paymentHistoryInputDto = GetPaymentHistoryDto(sslCommerzResponseDic, paymentHistory);
            //        await _paymentHistoryService.UpdateHistoryAsync(paymentHistoryInputDto);
            //    }
            //}
        }

        public async Task UpdateApplicantPaymentStatus(Dictionary<string, string> sslCommerzResponseDic)
        {
            //sslCommerzResponseDic.TryGetValue("tran_id", out string tran_id);
            //if (!string.IsNullOrWhiteSpace(tran_id))
            //{
            //    var paymentHistory = await _paymentHistoryService.GetByTranIdAsync(tran_id);
            //    if (paymentHistory != null)
            //    {
            //        if (!string.IsNullOrWhiteSpace(paymentHistory.application_code))
            //        {
            //            sslCommerzResponseDic.TryGetValue("amount", out string paid_amount);
            //            await UpdatePaymentStatus(paymentHistory.application_code, tran_id, paid_amount);
            //        }
            //    }
            //}
        }

        private async Task UpdatePaymentStatus(string application_code, string tran_id, string paid_amount)
        {
            //var applicant = _jobApplicationRepository.GetAll()
            //                            .Include(a => a.Applicant)
            //                            .Include(a => a.Circular)
            //                            .Include(a => a.Post)
            //                            .FirstOrDefault(a => a.ApplicationCode == application_code);
            //if (applicant != null && applicant.ApplicationStatus != ApplicationStatus.AppliedAndPaid)
            //{
            //    applicant.ApplicationStatus = ApplicationStatus.AppliedAndPaid;
            //    applicant.TransactionId = tran_id;
            //    applicant.FeePaid = string.IsNullOrWhiteSpace(paid_amount) ? 0 : double.Parse(paid_amount);

            //    await _jobApplicationRepository.UpdateAsync(applicant);

            //    await SendNotification(application_code, applicant.Applicant.Mobile);
            //}
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

        private PaymentHistoryInputDto GetPaymentHistoryDto(Dictionary<string, string> sslCommerzResponseDic, PaymentHistoryDto paymentHistoryDto)
        {
            sslCommerzResponseDic.TryGetValue("tran_id", out string tran_id);
            sslCommerzResponseDic.TryGetValue("val_id", out string val_id);
            sslCommerzResponseDic.TryGetValue("amount", out string amount);
            sslCommerzResponseDic.TryGetValue("card_type", out string card_type);
            sslCommerzResponseDic.TryGetValue("store_amount", out string store_amount);
            sslCommerzResponseDic.TryGetValue("card_no", out string card_no);
            sslCommerzResponseDic.TryGetValue("bank_tran_id", out string bank_tran_id);
            sslCommerzResponseDic.TryGetValue("status", out string status);
            sslCommerzResponseDic.TryGetValue("tran_date", out string tran_date);
            sslCommerzResponseDic.TryGetValue("error", out string error);
            sslCommerzResponseDic.TryGetValue("currency", out string currency);
            sslCommerzResponseDic.TryGetValue("card_issuer", out string card_issuer);
            sslCommerzResponseDic.TryGetValue("card_brand", out string card_brand);
            sslCommerzResponseDic.TryGetValue("card_sub_brand", out string card_sub_brand);
            sslCommerzResponseDic.TryGetValue("card_issuer_country", out string card_issuer_country);
            sslCommerzResponseDic.TryGetValue("card_issuer_country_code", out string card_issuer_country_code);
            sslCommerzResponseDic.TryGetValue("currency_type", out string currency_type);
            sslCommerzResponseDic.TryGetValue("currency_amount", out string currency_amount);
            sslCommerzResponseDic.TryGetValue("currency_rate", out string currency_rate);
            sslCommerzResponseDic.TryGetValue("base_fair", out string base_fair);
            sslCommerzResponseDic.TryGetValue("value_a", out string value_a);
            sslCommerzResponseDic.TryGetValue("value_b", out string value_b);
            sslCommerzResponseDic.TryGetValue("value_c", out string value_c);
            sslCommerzResponseDic.TryGetValue("value_d", out string value_d);
            sslCommerzResponseDic.TryGetValue("subscription_id", out string subscription_id);
            sslCommerzResponseDic.TryGetValue("risk_level", out string risk_level);
            sslCommerzResponseDic.TryGetValue("risk_title", out string risk_title);

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

        private static SslCommerzInitDto GetInitPaymentResponse(SSLCommerzInitResponse initResponse)
        {
            return new SslCommerzInitDto
            {
                status = initResponse.status,
                failedreason = initResponse.failedreason,
                GatewayPageURL = initResponse.GatewayPageURL
            };
        }

        private static SslCommerzDto GetFullInitPaymentResponse(SSLCommerzInitResponse initResponse)
        {
            return new SslCommerzDto
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
    }
}
