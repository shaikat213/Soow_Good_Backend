using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class PaymentHistoryService : SoowGoodWebAppService, IPaymentHistoryService
    {
        private readonly IRepository<PaymentHistory> _paymentHistoryRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public PaymentHistoryService(IRepository<PaymentHistory> paymentHistoryRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _paymentHistoryRepository = paymentHistoryRepository;

            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<PaymentHistoryDto> CreateAsync(PaymentHistoryInputDto input)
        {
            var newEntity = ObjectMapper.Map<PaymentHistoryInputDto, PaymentHistory>(input);

            var doctorProfile = await _paymentHistoryRepository.InsertAsync(newEntity);

            //await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<PaymentHistory, PaymentHistoryDto>(doctorProfile);
        }

        public async Task<PaymentHistoryDto> GetAsync(int id)
        {
            var item = await _paymentHistoryRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<PaymentHistory, PaymentHistoryDto>(item);
        }
        public async Task<List<PaymentHistoryDto>> GetListAsync()
        {
            var specialization = await _paymentHistoryRepository.GetListAsync();
            return ObjectMapper.Map<List<PaymentHistory>, List<PaymentHistoryDto>>(specialization);
        }
        public async Task<PaymentHistoryDto> UpdateAsync(PaymentHistoryInputDto input)
        {
            var updateItem = ObjectMapper.Map<PaymentHistoryInputDto, PaymentHistory>(input);

            var item = await _paymentHistoryRepository.UpdateAsync(updateItem);

            return ObjectMapper.Map<PaymentHistory, PaymentHistoryDto>(item);
        }
        public async Task<PaymentHistoryDto> GetByTranIdAsync(string tranId)
        {
            var item = await _paymentHistoryRepository.GetAsync(x => x.tran_id == tranId);

            return ObjectMapper.Map<PaymentHistory, PaymentHistoryDto>(item);
        }
        public async Task<string> GetByAppointmentCodeAsync(string appCode)
        {
            var item = await _paymentHistoryRepository.GetAsync(x => x.application_code == appCode);
            var tranId = item.tran_id;
            return (!string.IsNullOrEmpty(tranId) ? tranId : "");// ObjectMapper.Map<PaymentHistory, PaymentHistoryDto>(item);
        }
        public async Task<bool> UpdateHistoryAsync(PaymentHistoryInputDto input)
        {
            var paymentHistory = _paymentHistoryRepository.GetAsync(p=>p.Id == input.Id);
            //paymentHistory.tran_id = input.tran_id;
            //paymentHistory.sessionkey = input.sessionkey;
            //paymentHistory.application_code = input.application_code;
            paymentHistory.Result.val_id = input.val_id;
            paymentHistory.Result.amount = input.amount;
            paymentHistory.Result.card_type = input.card_type;
            paymentHistory.Result.store_amount = input.store_amount;
            paymentHistory.Result.card_no = input.card_no;
            paymentHistory.Result.bank_tran_id = input.bank_tran_id;
            paymentHistory.Result.status = input.status;
            paymentHistory.Result.tran_date = input.tran_date;
            paymentHistory.Result.failedreason = input.error;
            paymentHistory.Result.error = input.error;
            paymentHistory.Result.currency = input.currency;
            paymentHistory.Result.card_issuer = input.card_issuer;
            paymentHistory.Result.card_brand = input.card_brand;
            paymentHistory.Result.card_sub_brand = input.card_sub_brand;
            paymentHistory.Result.card_issuer_country = input.card_issuer_country;
            paymentHistory.Result.card_issuer_country_code = input.card_issuer_country_code;
            paymentHistory.Result.currency_type = input.currency_type;
            paymentHistory.Result.currency_amount = input.currency_amount;
            paymentHistory.Result.currency_rate = input.currency_rate;
            paymentHistory.Result.base_fair = input.base_fair;
            paymentHistory.Result.value_a = input.value_a;
            paymentHistory.Result.value_b = input.value_b;
            paymentHistory.Result.value_c = input.value_c;
            paymentHistory.Result.value_d = input.value_d;
            paymentHistory.Result.subscription_id = input.subscription_id;
            paymentHistory.Result.risk_level = input.risk_level;
            paymentHistory.Result.risk_title = input.risk_title;

            await _paymentHistoryRepository.UpdateAsync(paymentHistory.Result);

            return true;
        }

    }
}
