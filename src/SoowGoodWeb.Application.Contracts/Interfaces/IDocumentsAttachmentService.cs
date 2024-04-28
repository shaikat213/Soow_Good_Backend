using SoowGoodWeb.DtoModels;
using SoowGoodWeb.InputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb.Interfaces
{
    public interface IDocumentsAttachmentService : IApplicationService
    {
        //Task<List<DocumentsAttachmentDto>> GetListAsync();
        //Task<DocumentsAttachmentDto> GetAsync(int id);
        Task<DocumentsAttachmentDto> GetDocumentAsync(string entityType, long? entityId, string attachmentType);
        //Task<SpecialityDto> CreateAsync(SpecializationInputDto input);
        //Task<SpecialityDto> UpdateAsync(SpecializationInputDto input);
    }
}
