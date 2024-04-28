using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SoowGoodWeb.Enums;
using System.Collections.Generic;
using System.IO;
using System;
using System.Net.Http.Headers;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using SoowGoodWeb.InputDto;
using SoowGoodWeb.Models;
using Volo.Abp.Uow;
using System.Threading.Tasks;
using SoowGoodWeb.DtoModels;
using System.Net.Mail;
using Attachment = SoowGoodWeb.Models.Attachment;
using Volo.Abp.ObjectMapping;
using SoowGoodWeb.Interfaces;
using System.Linq.Dynamic.Core;
using System.Linq;


namespace SoowGoodWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : AbpController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRepository<DocumentsAttachment> _attachmentRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public CommonController(
            IWebHostEnvironment webHostEnvironment,
            IRepository<DocumentsAttachment> attachmentRepository,
            IUnitOfWorkManager unitOfWorkManager
           )
        {
            _webHostEnvironment = webHostEnvironment;
            _attachmentRepository = attachmentRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [HttpPost, ActionName("Documents")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> FileUploadDocuments()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                long attchmentId = 0;
                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    var idStr = Request.Form["entityId"].ToString();
                    var relatedIdStr = Request.Form["relatedEntityid"].ToString();
                    long entityId = string.IsNullOrEmpty(idStr) ? 0 : Convert.ToInt64(idStr);
                    long relatedEntityid = string.IsNullOrEmpty(relatedIdStr) ? 0 : Convert.ToInt64(relatedIdStr);
                    var entityType = Request.Form["entityType"].ToString();
                    var attachmentType = Request.Form["attachmentType"].ToString();
                    var directoryName = Request.Form["directoryName"][0];
                    var folderName = Path.Combine("wwwroot", "uploads", !string.IsNullOrEmpty(directoryName) ? directoryName : "Misc");
                    int insertCount = 0;
                    foreach (var file in files)
                    {
                        if (!Directory.Exists(folderName))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(folderName);
                        }

                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // save attachment
                        if (entityType != EntityType.Patient.ToString() && entityType != AttachmentType.PatientPreviousDocuments.ToString())
                        {
                            if (attachmentType == AttachmentType.ProfilePicture.ToString() || attachmentType == AttachmentType.DoctIdentityDoc.ToString())
                            {
                                attchmentId = await GetDocumentIdAsync(entityType, entityId, attachmentType);
                            }


                            if (attchmentId > 0)
                            {
                                var deletResult = await DeleteDocAsync(attchmentId); //await UpdateUploadAsync(attachementDto);
                                if (deletResult == true)
                                {
                                    var attachement2 = new DocumentsAttachment();
                                    attachement2.FileName = idStr + "_" + fileName;
                                    attachement2.OriginalFileName = fileName;
                                    attachement2.Path = dbPath;
                                    attachement2.EntityType = (EntityType)Enum.Parse(typeof(EntityType), entityType);
                                    attachement2.EntityId = entityId;
                                    attachement2.AttachmentType = (AttachmentType)Enum.Parse(typeof(AttachmentType), attachmentType);
                                    attachement2.RelatedEntityid = relatedEntityid > 0 ? relatedEntityid : null;
                                    var attachmentResult = await _attachmentRepository.InsertAsync(attachement2, autoSave: true);
                                    if (attachmentResult != null)//  == 0)
                                    {
                                        insertCount += 1;
                                    }
                                }
                            }
                            else
                            {
                                var attachement = new DocumentsAttachment();
                                attachement.FileName = idStr + "_" + fileName;
                                attachement.OriginalFileName = fileName;
                                attachement.Path = dbPath;
                                attachement.EntityType = (EntityType)Enum.Parse(typeof(EntityType), entityType);
                                attachement.EntityId = entityId;
                                attachement.AttachmentType = (AttachmentType)Enum.Parse(typeof(AttachmentType), attachmentType);
                                attachement.RelatedEntityid = relatedEntityid > 0 ? relatedEntityid : null;
                                var attachmentResult = await _attachmentRepository.InsertAsync(attachement, autoSave: true);
                                if (attachmentResult != null)//  == 0)
                                {
                                    insertCount += 1;
                                }
                            }
                        }
                        else
                        {
                            var attachement = new DocumentsAttachment();
                            attachement.FileName = idStr + "_" + fileName;
                            attachement.OriginalFileName = fileName;
                            attachement.Path = dbPath;
                            attachement.EntityType = (EntityType)Enum.Parse(typeof(EntityType), entityType);
                            attachement.EntityId = entityId;
                            attachement.AttachmentType = (AttachmentType)Enum.Parse(typeof(AttachmentType), attachmentType);
                            attachement.RelatedEntityid = relatedEntityid > 0 ? relatedEntityid : null;
                            var attachmentResult = await _attachmentRepository.InsertAsync(attachement, autoSave: true);
                            if (attachmentResult != null)//  == 0)
                            {
                                insertCount += 1;
                            }
                        }

                        dbPath = dbPath.Replace(@"wwwroot\", string.Empty);
                    }
                    if (insertCount > 0)
                    {
                        result.Add("Status", "Success");
                        result.Add("Message", "Data save successfully!");
                    }
                    else
                    {
                        result.Add("Status", "Warning");
                        result.Add("Message", "Fail to save!");
                    }
                    return new JsonResult(result);
                }
                else
                {
                    result.Add("Status", "Warning");
                    result.Add("Message", "Attachment not found!");
                    return new JsonResult(result);
                }
            }
            catch (Exception ex)
            {
                result.Add("Status", "Error");
                result.Add("Message", $"Internal server error: {ex}");
                return new JsonResult(result);
            }
        }

        [HttpPost, ActionName("DeleteFileComplain")]
        public IActionResult DeleteFileComplain(FileDeleteInputDto input)
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, input.FilePath);
                FileInfo fi = new FileInfo(filePath);
                if (fi != null)
                {
                    System.IO.File.Delete(filePath);
                    fi.Delete();
                }
                return new JsonResult(input.FilePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost, ActionName("DeleteFileAllotment")]
        public IActionResult DeleteFileAllotment(FileDeleteInputDto input)
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, input.FilePath);
                FileInfo fi = new FileInfo(filePath);
                if (fi != null)
                {
                    System.IO.File.Delete(filePath);
                    fi.Delete();
                }
                return new JsonResult(input.FilePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        public async Task<long> GetDocumentAsync(string entityType, long? entityId, string attachmentType, string fileName)
        {
            try
            {
                var queryable = await _attachmentRepository.WithDetailsAsync();
                var attachment = queryable.Where(x => x.EntityType == (EntityType)Enum.Parse(typeof(EntityType), entityType)
                                                                && x.EntityId == entityId
                                                                && x.AttachmentType == (AttachmentType)Enum.Parse(typeof(AttachmentType), attachmentType)
                                                                && x.OriginalFileName == fileName
                                                                && x.IsDeleted == false).FirstOrDefault();
                //var item = attachment.re;
                if (attachment != null && attachment.Id > 0)
                {
                    return attachment.Id;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;

        }

        [HttpGet]
        public async Task<long> GetDocumentIdAsync(string entityType, long? entityId, string attachmentType)
        {
            try
            {
                var queryable = await _attachmentRepository.WithDetailsAsync();
                var attachment = queryable.Where(x => x.EntityType == (EntityType)Enum.Parse(typeof(EntityType), entityType)
                                                                && x.EntityId == entityId
                                                                && x.AttachmentType == (AttachmentType)Enum.Parse(typeof(AttachmentType), attachmentType)
                                                                && x.IsDeleted == false).FirstOrDefault();
                //var item = attachment.re;
                if (attachment != null && attachment.Id > 0)
                {
                    return attachment.Id;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;

        }

        //[HttpPut]
        //public async Task<DocumentsAttachmentDto> UpdateUploadAsync(DocumentsAttachmentDto input)
        //{
        //    var updateItem = ObjectMapper.Map<DocumentsAttachmentDto, DocumentsAttachment>(input);

        //    var item = await _attachmentRepository.UpdateAsync(updateItem);

        //    return ObjectMapper.Map<DocumentsAttachment, DocumentsAttachmentDto>(item);
        //}

        [HttpDelete]
        public async Task<bool> DeleteDocAsync(long id)
        {
            try
            {
                await _attachmentRepository.DeleteAsync((x => x.Id == id), autoSave: true);//.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //[HttpPost, ActionName("Allotment")]
        //[DisableRequestSizeLimit]
        //public IActionResult FileUploadAllotment()
        //{
        //    Dictionary<string, string> result = new Dictionary<string, string>();
        //    try
        //    {
        //        var files = Request.Form.Files;
        //        if (files.Count > 0)
        //        {
        //            var allotmentIdStr = Request.Form["allotmentId"].ToString();
        //            int allotmentId = string.IsNullOrEmpty(allotmentIdStr) ? 0 : Convert.ToInt32(allotmentIdStr);
        //            var entityType = Request.Form["entityType"].ToString();
        //            if (string.IsNullOrEmpty(entityType))
        //            {
        //                entityType = "None";
        //            }
        //            var attachmentType = Request.Form["attachmentType"].ToString();
        //            if (string.IsNullOrEmpty(attachmentType))
        //            {
        //                attachmentType = "None";
        //            }
        //            var directoryName = Request.Form["directoryName"][0];
        //            var folderName = Path.Combine("wwwroot", "uploads", directoryName);
        //            int insertCount = 0;

        //            foreach (var file in files)
        //            {
        //                if (!Directory.Exists(folderName))
        //                {
        //                    DirectoryInfo di = Directory.CreateDirectory(folderName);
        //                }

        //                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //                var fullPath = Path.Combine(pathToSave, fileName);
        //                var dbPath = Path.Combine(folderName, fileName);
        //                using (var stream = new FileStream(fullPath, FileMode.Create))
        //                {
        //                    file.CopyTo(stream);
        //                }
        //                // save attachment
        //                var attachement = new Attachment();
        //                attachement.FileName = fileName;
        //                attachement.OriginalFileName = fileName;
        //                attachement.Path = dbPath;
        //                attachement.EntityType = (EntityType)Enum.Parse(typeof(EntityType), entityType);
        //                attachement.EntityId = allotmentId;
        //                attachement.AttachmentType = (AttachmentType)Enum.Parse(typeof(AttachmentType), attachmentType);
        //                attachmentRepository.InsertAsync(attachement);
        //                insertCount += 1;
        //                dbPath = dbPath.Replace(@"wwwroot\", string.Empty);
        //            }

        //            if (insertCount > 0)
        //            {
        //                result.Add("Status", "Success");
        //                result.Add("Message", "Data save successfully!");
        //            }
        //            else
        //            {
        //                result.Add("Status", "Warning");
        //                result.Add("Message", "Fail to save!");
        //            }

        //            return new JsonResult(result);
        //        }
        //        else
        //        {
        //            result.Add("Status", "Warning");
        //            result.Add("Message", "Attachment not found!");
        //            return new JsonResult(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Add("Status", "Error");
        //        result.Add("Message", $"Internal server error: {ex}");
        //        return new JsonResult(result);
        //    }
        //}
    }
}
// CICD Testing