using SoowGoodWeb.DtoModels;
using SoowGoodWeb.Enums;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Interfaces;
using SoowGoodWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace SoowGoodWeb.Services
{
    public class FinancialSetupService : SoowGoodWebAppService, IFinancialSetupService
    {
        private readonly IRepository<FinancialSetup> _financialSetupRepository;
        private readonly IRepository<PlatformFacility> _platformFacilityRepository;
        private readonly IRepository<DoctorProfile> _doctorProfileRepository;
        private readonly IRepository<ServiceProvider> _serviceProviderRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public FinancialSetupService(IRepository<FinancialSetup> financialSetupRepository, IRepository<PlatformFacility> platformFacilityRepository, IRepository<DoctorProfile> doctorProfileRepository, IRepository<ServiceProvider> serviceProviderRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _financialSetupRepository = financialSetupRepository;
            _platformFacilityRepository = platformFacilityRepository;
            _doctorProfileRepository = doctorProfileRepository;
            _serviceProviderRepository = serviceProviderRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<FinancialSetupDto> CreateAsync(FinancialSetupInputDto input)
        {
            var result = new FinancialSetupDto();
            var platformFacility = await _platformFacilityRepository.GetAsync(d => d.Id == input.PlatformFacilityId);
            var newEntity = ObjectMapper.Map<FinancialSetupInputDto, FinancialSetup>(input);

            var financialSetup = await _financialSetupRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();
            result = ObjectMapper.Map<FinancialSetup, FinancialSetupDto>(financialSetup);
            result.FacilityName = platformFacility.ServiceName;
            return result;//ObjectMapper.Map<FinancialSetup, FinancialSetupDto>(result);
        }

        public async Task<FinancialSetupDto> GetAsync(int id)
        {
            var item = await _financialSetupRepository.GetAsync(x => x.Id == id);

            return ObjectMapper.Map<FinancialSetup, FinancialSetupDto>(item);
        }
        public async Task<List<FinancialSetupDto>> GetListAsync()
        {
            List<FinancialSetupDto>? result = null;
            var facilityEntityName = "";
            var allFinancialSetupDetails = await _financialSetupRepository.WithDetailsAsync(p => p.PlatformFacility);
            if (!allFinancialSetupDetails.Any())
            {
                return result;
            }
            result = new List<FinancialSetupDto>();
            foreach (var item in allFinancialSetupDetails)
            {
                if (item.FacilityEntityID > 0)
                {
                    if (item.FacilityEntityType == FacilityEntityType.DoctorConsultation)
                    {
                        var doctorP = await _doctorProfileRepository.GetAsync(d => d.Id == item.FacilityEntityID);
                        facilityEntityName = doctorP.FullName;
                    }
                    else if (item.FacilityEntityType == FacilityEntityType.ServiceFacility)
                    {
                        var sp = await _serviceProviderRepository.GetAsync(d => d.Id == item.FacilityEntityID);
                        facilityEntityName = sp.ProviderOrganizationName;
                    }
                }
                result.Add(new FinancialSetupDto()
                {

                    Id = item.Id,
                    PlatformFacilityId = item.PlatformFacilityId,

                    FacilityName = item.PlatformFacilityId > 0 ? item.PlatformFacility?.ServiceName : "N/A",
                    FacilityEntityType = item.FacilityEntityType,
                    FacilityEntityTypeName = item.FacilityEntityType > 0 ? item.FacilityEntityType.ToString() : "N/A",
                    DiagonsticServiceType = item.DiagonsticServiceType,
                    DiagonsticServiceTypeName = item.DiagonsticServiceType > 0 ? item.DiagonsticServiceType.ToString() : "N/A",
                    FacilityEntityID = item.FacilityEntityID,
                    FacilityEntityName = item.FacilityEntityID > 0 ? facilityEntityName : "N/A",
                    AmountIn = item.AmountIn,
                    Amount = item.Amount,
                    ExternalAmount = item.ExternalAmount > 0 ? item.ExternalAmount : 0,
                    ExternalAmountIn = item.ExternalAmountIn != null ? item.ExternalAmountIn : "N/A",
                    IsActive = item.IsActive,
                    ProviderAmount = item.ProviderAmount > 0 ? item.ProviderAmount : 0,
                    Vat = item.Vat
                });
            }
            var resList = result.OrderByDescending(d => d.Id).ToList();
            return resList;
        }

        public async Task<List<FinancialSetupDto>> GetListByProviderIdandTypeAsync(FacilityEntityType? providerType, long? providerId, string? userRole)
        {
            List<FinancialSetupDto>? result = null;
            var facilityEntityName = "";
            var allFinancialSetups = await _financialSetupRepository.WithDetailsAsync(p => p.PlatformFacility);
            var allFinancialSetupDetails = allFinancialSetups.Where(p => p.IsActive == true).ToList();
            if (userRole == "patient")
            {
                allFinancialSetupDetails = allFinancialSetupDetails.Where(p => p.FacilityEntityID == providerId && p.FacilityEntityType == providerType && (p.PlatformFacilityId == 1 || p.PlatformFacilityId == 2 || p.PlatformFacilityId == 3)).ToList();
            }
            else if (userRole == "agent")
            {
                allFinancialSetupDetails = allFinancialSetupDetails.Where(p => p.FacilityEntityID == providerId && p.FacilityEntityType == providerType && (p.PlatformFacilityId == 4 || p.PlatformFacilityId == 5 || p.PlatformFacilityId == 6)).ToList();
            }
            if (!allFinancialSetupDetails.Any())
            {
                allFinancialSetupDetails = allFinancialSetups.Where(p => p.FacilityEntityID == null && p.FacilityEntityType == providerType && p.IsActive == true).ToList();

            }
            //if (!allFinancialSetupDetails.Any())
            //{
            //    return null;
            //}
            result = new List<FinancialSetupDto>();
            foreach (var item in allFinancialSetupDetails)
            {
                if (item.FacilityEntityID > 0)
                {
                    if (item.FacilityEntityType == FacilityEntityType.DoctorConsultation)
                    {
                        var doctorP = await _doctorProfileRepository.GetAsync(d => d.Id == item.FacilityEntityID);
                        facilityEntityName = doctorP.FullName;
                    }
                    else if (item.FacilityEntityType == FacilityEntityType.ServiceFacility)
                    {
                        var sp = await _serviceProviderRepository.GetAsync(d => d.Id == item.FacilityEntityID);
                        facilityEntityName = sp.ProviderOrganizationName;
                    }
                }
                result.Add(new FinancialSetupDto()
                {

                    Id = item.Id,
                    PlatformFacilityId = item.PlatformFacilityId,

                    FacilityName = item.PlatformFacilityId > 0 ? item.PlatformFacility?.ServiceName : "N/A",
                    FacilityEntityType = item.FacilityEntityType,
                    FacilityEntityTypeName = item.FacilityEntityType > 0 ? item.FacilityEntityType.ToString() : "N/A",
                    DiagonsticServiceType = item.DiagonsticServiceType,
                    DiagonsticServiceTypeName = item.DiagonsticServiceType > 0 ? item.DiagonsticServiceType.ToString() : "N/A",
                    FacilityEntityID = item.FacilityEntityID,
                    FacilityEntityName = item.FacilityEntityID > 0 ? facilityEntityName : "N/A",
                    AmountIn = item.AmountIn,
                    Amount = item.Amount,
                    ExternalAmount = item.ExternalAmount > 0 ? item.ExternalAmount : 0,
                    ExternalAmountIn = item.ExternalAmountIn != null ? item.ExternalAmountIn : "N/A",
                    IsActive = item.IsActive,
                    ProviderAmount = item.ProviderAmount > 0 ? item.ProviderAmount : 0,
                    Vat = item.Vat
                });
            }
            var resList = result.OrderByDescending(d => d.Id).ToList();
            return resList;
        }

        public async Task<FinancialSetupDto> UpdateAsync(FinancialSetupInputDto input)
        {
            //var updateItem = ObjectMapper.Map<FinancialSetupInputDto, FinancialSetup>(input);

            //var item = await _financialSetupRepository.UpdateAsync(updateItem);

            //return ObjectMapper.Map<FinancialSetup, FinancialSetupDto>(item);


            var result = new FinancialSetupDto();
            try
            {
                var itemFinSetup = await _financialSetupRepository.GetAsync(d => d.Id == input.Id);
                if (itemFinSetup != null)
                {
                    itemFinSetup.PlatformFacilityId = input.PlatformFacilityId;
                    itemFinSetup.FacilityEntityType = input.FacilityEntityType;
                    itemFinSetup.DiagonsticServiceType = input.DiagonsticServiceType;
                    itemFinSetup.FacilityEntityID = input.FacilityEntityID;
                    itemFinSetup.AmountIn = input.AmountIn;
                    itemFinSetup.Amount = input.Amount;
                    itemFinSetup.ExternalAmountIn = input.ExternalAmountIn;
                    itemFinSetup.ExternalAmount = input.ExternalAmount;
                    itemFinSetup.ProviderAmount = input.ProviderAmount;
                    itemFinSetup.IsActive = input.IsActive;
                    itemFinSetup.Vat = input.Vat;


                    var item = await _financialSetupRepository.UpdateAsync(itemFinSetup);
                    await _unitOfWorkManager.Current.SaveChangesAsync();
                    result = ObjectMapper.Map<FinancialSetup, FinancialSetupDto>(item);
                }
            }
            catch (Exception ex)
            {
            }
            return result;//ObjectMapper.Map<DoctorProfile, DoctorProfileDto>(item);
        }

        public async Task DeleteAsync(long id)
        {
            await _financialSetupRepository.DeleteAsync(d => d.Id == id);
        }

        public async Task<decimal> GetToalDiscountAmountTotalProviderAmountAsync(decimal amount)
        {
            decimal? finsetupAmnt = 0;
            decimal? discountAmnt = 0;
            //decimal? finalAmnt = 0;
            var finSetup = await _financialSetupRepository.WithDetailsAsync();

            var finsetupAmntIn = finSetup.FirstOrDefault(f => f.PlatformFacilityId == 7 && f.DiagonsticServiceType == DiagonsticServiceType.General)?.AmountIn;
            if (finsetupAmntIn == "Percentage")
            {
                finsetupAmnt = finSetup.FirstOrDefault(a => a.PlatformFacilityId == 7 && a.DiagonsticServiceType == DiagonsticServiceType.General && a.AmountIn == finsetupAmntIn)?.Amount;
                discountAmnt = (amount * finsetupAmnt) / 100;
                //finalAmnt = item.ProviderRate - discountAmnt;
            }
            else
            {
                finsetupAmnt = finSetup.FirstOrDefault(a => a.PlatformFacilityId == 7 && a.DiagonsticServiceType == DiagonsticServiceType.General && a.AmountIn == finsetupAmntIn)?.Amount;
                discountAmnt = finsetupAmnt;
                //finalAmnt = item.ProviderRate - discountAmnt;
            }

            return discountAmnt > 0 ? (decimal)discountAmnt : 0;
            //ObjectMapper.Map<FinancialSetup, FinancialSetupDto>(item);
        }

    }
}
