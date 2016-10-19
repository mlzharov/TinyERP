using App.Common;
using App.Common.DI;
using App.Common.Helpers;
using App.Common.Http;
using App.Common.MVC.Attributes;
using App.Common.Providers;
using App.Common.Validation;
using App.Service.Common.File;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
namespace App.Api.Features.Common
{
    [RoutePrefix("api/files")]
    public class FilesController : ApiController
    {
        [HttpGet]
        [Route("{id}/thumbnail/{size?}")]
        public HttpResponseMessage CreateThumbnail(Guid id, ThumbnailSize size = ThumbnailSize.Medium)
        {
            IFileService service = IoC.Container.Resolve<IFileService>();
            Bitmap bitmap = service.GetThumbnail(id, size);
            byte[] imageContent = ImageHelper.GetContent(bitmap);

            MemoryStream ms = new MemoryStream(imageContent);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }
        [HttpPost]
        [Route("")]
        [ValidateMimeMultipartContentFilter]
        public async Task<IResponseData<IList<FileUploadResponse>>> UploadFile()
        {
            MultipartFormDataMemoryStreamProvider provider = new MultipartFormDataMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            IResponseData<IList<FileUploadResponse>> response = new ResponseData<IList<FileUploadResponse>>();
            try
            {
                IFileService service = IoC.Container.Resolve<IFileService>();
                IList<FileUploadResponse> fileUploadResponse = service.UploadFiles(provider.FileData);
                response.SetData(fileUploadResponse);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }


        //[HttpGet]
        //[Route("{fileId}")]
        //public IResponseData<App.Entity.Common.File> GetFile(Guid fileId)
        //{
        //    IResponseData<App.Entity.Common.File> response = new ResponseData<App.Entity.Common.File>();
        //    try
        //    {
        //        IFileService service = IoC.Container.Resolve<IFileService>();
        //        response.SetData(service.GetById(fileId));
        //    }
        //    catch (ValidationException ex)
        //    {
        //        response.SetErrors(ex.Errors);
        //        response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
        //    }
        //    return response;
        //}
    }
}