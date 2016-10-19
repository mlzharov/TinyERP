using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Security;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace App.Api.Features.Security
{
    [RoutePrefix("api/roles")]
    public class RolesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<RoleListItemSummary>> GetRoles()
        {
            IResponseData<IList<RoleListItemSummary>> response = new ResponseData<IList<RoleListItemSummary>>();
            try
            {
                IRoleService roleService = IoC.Container.Resolve<IRoleService>();
                IList<RoleListItemSummary> roles=roleService.GetRoles();
                response.SetData(roles);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public IResponseData<GetRoleResponse> GetRole(Guid id)
        {
            IResponseData<GetRoleResponse> response = new ResponseData<GetRoleResponse>();
            try
            {
                IRoleService roleService = IoC.Container.Resolve<IRoleService>();
                GetRoleResponse role = roleService.Get(id);
                response.SetData(role);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpPost]
        [Route("")]
        public IResponseData<CreateRoleResponse> CreateRole(CreateRoleRequest request)
        {
            IResponseData<CreateRoleResponse> response = new ResponseData<CreateRoleResponse>();
            try
            {
                IRoleService roleService = IoC.Container.Resolve<IRoleService>();
                CreateRoleResponse role = roleService.Create(request);
                response.SetData(role);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public IResponseData<string> UpdateRole(Guid id, UpdateRoleRequest request)
        {
            request.Id = id;
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IRoleService roleService = IoC.Container.Resolve<IRoleService>();
                roleService.Update(request);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public IResponseData<string> DeleteRole(Guid id)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IRoleService roleService = IoC.Container.Resolve<IRoleService>();
                roleService.Delete(id);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }
    }
}
