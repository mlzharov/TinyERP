using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Security;
using App.Service.Security.UserGroup;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace App.Api.Features.Security
{
    [RoutePrefix("api/usergroups")]
    public class UserGroupsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<UserGroupListItemSummary>> GetUserGroups()
        {
            IResponseData<IList<UserGroupListItemSummary>> response = new ResponseData<IList<UserGroupListItemSummary>>();
            try
            {
                IUserGroupService userGroupService = IoC.Container.Resolve<IUserGroupService>();
                IList<UserGroupListItemSummary> userGroups=userGroupService.GetUserGroups();
                response.SetData(userGroups);
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
        public IResponseData<GetUserGroupResponse> GetRole(Guid id)
        {
            IResponseData<GetUserGroupResponse> response = new ResponseData<GetUserGroupResponse>();
            try
            {
                IUserGroupService service = IoC.Container.Resolve<IUserGroupService>();
                GetUserGroupResponse role = service.Get(id);
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
        public IResponseData<CreateUserGroupResponse> CreateUserGroup(CreateUserGroupRequest request)
        {
            IResponseData<CreateUserGroupResponse> response = new ResponseData<CreateUserGroupResponse>();
            try
            {
                IUserGroupService userGroupService = IoC.Container.Resolve<IUserGroupService>();
                CreateUserGroupResponse userGroupResponse = userGroupService.Create(request);
                response.SetData(userGroupResponse);
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
                IUserGroupService service = IoC.Container.Resolve<IUserGroupService>();
                service.Delete(id);
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
        public IResponseData<string> UpdateUserGroup(Guid id, UpdateUserGroupRequest request)
        {
            request.Id = id;
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IUserGroupService roleService = IoC.Container.Resolve<IUserGroupService>();
                roleService.Update(request);
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
