using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Setting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace App.Api.Features.Setting
{
    [RoutePrefix("api/contenttypes")]
    public class ContentTypesController : ApiController
    {
        [Route("{id}")]
        [HttpPut]
        public IResponseData<bool> UpdateContentType(UpdateContentTypeRequest request)
        {
            IResponseData<bool> response = new ResponseData<bool>();
            try
            {
                IContentTypeService service = IoC.Container.Resolve<IContentTypeService>();
                service.Update(request);
                response.SetData(true);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [Route("")]
        [HttpPost]
        public IResponseData<bool> CreateContentType(CreateContentTypeRequest request)
        {
            IResponseData<bool> response = new ResponseData<bool>();
            try
            {
                IContentTypeService service = IoC.Container.Resolve<IContentTypeService>();
                service.Create(request);
                response.SetData(true);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [Route("{id}")]
        [HttpGet]
        public IResponseData<GetContentTypeResponse> GetContentType(Guid id)
        {
            IResponseData<GetContentTypeResponse> response = new ResponseData<GetContentTypeResponse>();
            try
            {
                IContentTypeService service = IoC.Container.Resolve<IContentTypeService>();
                GetContentTypeResponse item = service.Get(id);
                response.SetData(item);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return response;
        }
        [Route("{id}")]
        [HttpDelete]
        public IResponseData<bool> DeleteContentType(Guid id)
        {
            IResponseData<bool> response = new ResponseData<bool>();
            try
            {
                IContentTypeService service = IoC.Container.Resolve<IContentTypeService>();
                service.Delete(id);
                response.SetData(true);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [Route("")]
        [HttpGet]
        public IResponseData<IList<ContentTypeListItem>> GetContentTypes()
        {
            IResponseData<IList<ContentTypeListItem>> response = new ResponseData<IList<ContentTypeListItem>>();
            try
            {
                IContentTypeService service = IoC.Container.Resolve<IContentTypeService>();
                IList<ContentTypeListItem> items = service.GetContentTypes();
                response.SetData(items);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return response;
        }
    }
}