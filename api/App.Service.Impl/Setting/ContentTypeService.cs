using System;
using System.Collections.Generic;
using App.Service.Setting;
using App.Common.DI;
using App.Repository.Setting;
using App.Entity.Setting;
using App.Common.Data;
using App.Context;
using App.Common;
using App.Common.Validation;
using App.Repository.Common;
using App.Entity.Common;
using System.Linq;

namespace App.Service.Impl.Setting
{
    public class ContentTypeService : IContentTypeService
    {
        public void Create(CreateContentTypeRequest request)
        {
            ValidateCreateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>(uow);
                ContentType contentType = new ContentType(request.Name, request.Key, request.Description);
                UpdateParameters(contentType.Id, request.Parameters, uow);
                repo.Add(contentType);
                uow.Commit();
            }
        }

        private void ValidateCreateRequest(CreateContentTypeRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("common.errors.invalidRequest");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.nameIsRequired");
            }
            IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>();
            if (repo.GetByName(request.Name) != null)
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.nameAlreadyExisted");
            }

            if (string.IsNullOrWhiteSpace(request.Key))
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.keyIsRequired");
            }
            if (request.Key.Contains(" "))
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.keyShouldNotHaveWhiteSpace");
            }

            if (repo.GetByKey(request.Key) != null)
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.keyAlreadyExisted");
            }
        }

        public void CreateIfNotExist(IList<CreateContentTypeRequest> request)
        {
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>(uow);
                foreach (CreateContentTypeRequest item in request)
                {
                    if (repo.GetByKey(item.Key) != null) { continue; }
                    ContentType contentType = new ContentType(item.Name, item.Key, item.Description);
                    repo.Add(contentType);
                }
                uow.Commit();
            }
        }

        public void Delete(Guid id)
        {
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>(uow);
                repo.Delete(id.ToString());
                uow.Commit();
            }
        }

        public GetContentTypeResponse Get(Guid id)
        {
            IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>();
            GetContentTypeResponse response = repo.GetById<GetContentTypeResponse>(id.ToString());
            IParameterRepository paramRepo = IoC.Container.Resolve<IParameterRepository>();
            response.Parameters = paramRepo.GetByParentId(id, ParameterParentType.ContentType);
            return response;
        }

        public IList<ContentTypeListItem> GetContentTypes()
        {
            IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>();
            return repo.GetItems<ContentTypeListItem>();
        }

        public void Update(UpdateContentTypeRequest request)
        {
            ValidateUpdateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>(uow);
                ContentType contentType = repo.GetById(request.Id.ToString());
                contentType.Name = request.Name;
                contentType.Key = request.Key;
                contentType.Description = request.Description;
                UpdateParameters(contentType.Id, request.Parameters, uow);
                repo.Update(contentType);
                uow.Commit();
            }
        }

        private void UpdateParameters(Guid contentId, IList<Parameter> parameters, IUnitOfWork uow)
        {
            IParameterRepository paramRepo = IoC.Container.Resolve<IParameterRepository>(uow);
            IList<Parameter> currentParams = paramRepo.GetByParentId(contentId, ParameterParentType.ContentType);
            foreach (Parameter param in currentParams)
            {
                if (parameters.Any(item => item.Id == param.Id)) { continue; }
                paramRepo.Delete(param.Id.ToString());
            }

            foreach (Parameter param in currentParams)
            {
                if (!parameters.Any(item => item.Id == param.Id)) { continue; }
                Parameter modifiedParam = parameters.FirstOrDefault(item => item.Id == param.Id);
                param.UpdateFrom(modifiedParam);
                paramRepo.Update(param);
            }

            foreach (Parameter param in parameters)
            {
                if (currentParams.Any(item => item.Id == param.Id)) { continue; }
                //if (param.Id != null && param.Id != Guid.Empty) { continue; }
                Parameter newParam = new Parameter();
                newParam.CreateFrom(param);
                newParam.ParentType = ParameterParentType.ContentType;
                newParam.ParentId = contentId;
                paramRepo.Add(newParam);
            }
        }

        private void ValidateUpdateRequest(UpdateContentTypeRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("common.errors.invalidRequest");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.nameIsRequired");
            }
            IContentTypeRepository repo = IoC.Container.Resolve<IContentTypeRepository>();
            ContentType contentType = repo.GetByName(request.Name);
            if (contentType != null && contentType.Id != request.Id)
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.nameAlreadyExisted");
            }

            if (string.IsNullOrWhiteSpace(request.Key))
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.keyIsRequired");
            }
            if (request.Key.Contains(" "))
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.keyShouldNotHaveWhiteSpace");
            }
            contentType = repo.GetByKey(request.Key);
            if (contentType != null && contentType.Id != request.Id)
            {
                throw new ValidationException("setting.addOrUpdateContentType.validation.keyAlreadyExisted");
            }
        }
    }
}
