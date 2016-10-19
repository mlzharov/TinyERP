using System;
using System.Collections.Generic;
using App.Service.Security;
using App.Common.DI;
using App.Repository.Secutiry;
using App.Entity.Security;
using App.Common;
using App.Common.Data;
using App.Common.Validation;
using App.Context;
using System.Linq;

namespace App.Service.Impl.Security
{
    public class RoleService : IRoleService
    {
        public void CreateIfNotExist(IList<Role> roles)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IRoleRepository roleRepository = IoC.Container.Resolve<IRoleRepository>(uow);
                foreach (Role role in roles)
                {
                    if (roleRepository.GetByKey(role.Key) != null) { continue; }
                    roleRepository.Add(role);
                }
                uow.Commit();
            }
        }
        public void Create(IList<Role> roles)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IRoleRepository roleRepository = IoC.Container.Resolve<IRoleRepository>(uow);
                foreach (Role role in roles)
                {
                    ValidationForCreating(role, roleRepository);
                    roleRepository.Add(role);
                }
                uow.Commit();
            }
        }
        private void ValidationForCreating(Role role, IRoleRepository repo)
        {
            if (string.IsNullOrWhiteSpace(role.Name))
            {
                throw new App.Common.Validation.ValidationException("security.addOrUpdateRole.validation.nameIsRequire");
            }
            //if (string.IsNullOrWhiteSpace(role.Key))
            //{
            //    throw new App.Common.Validation.ValidationException("security.addRole.validation.keyIsRequire");
            //}
            //if (repo.GetByKey(role.Key) != null)
            //{
            //    throw new App.Common.Validation.ValidationException("security.addRole.validation.keyIsExisted");
            //}
        }
        public CreateRoleResponse Create(CreateRoleRequest request)
        {
            Validate(request);
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IRoleRepository roleRepository = IoC.Container.Resolve<IRoleRepository>(uow);
                IPermissionRepository permissionRepo = IoC.Container.Resolve<IPermissionRepository>(uow);
                IList<Permission> permissions = permissionRepo.GetPermissions(request.Permissions);
                Role role = new Role(request.Name, request.Description, permissions);
                roleRepository.Add(role);
                uow.Commit();
            }
            return new CreateRoleResponse();
        }
        private void Validate(CreateRoleRequest request)
        {
            Role role = new Role(request.Name, request.Description, null);
            IRoleRepository roleRepo = IoC.Container.Resolve<IRoleRepository>();
            ValidationForCreating(role, roleRepo);
        }

        public IList<RoleListItemSummary> GetRoles()
        {
            IRoleRepository repository = IoC.Container.Resolve<IRoleRepository>();
            return repository.GetItems<RoleListItemSummary>();
        }

        public DeleteRoleResponse Delete(Guid id)
        {
            ValidationForDeleting(id);
            using (IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IRoleRepository repository = IoC.Container.Resolve<IRoleRepository>(uow);
                DeleteRoleResponse deleteResponse = repository.GetById<DeleteRoleResponse>(id.ToString());
                repository.Delete(id.ToString());
                uow.Commit();
                return deleteResponse;
            }
        }
        private void ValidationForDeleting(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new ValidationException("security.roles.validation.idIsInvalid");
            }
            IRoleRepository repository = IoC.Container.Resolve<IRoleRepository>();
            if (repository.GetById(id.ToString()) == null)
            {
                throw new ValidationException("security.roles.validation.roleNotExist");
            }
        }

        public GetRoleResponse Get(Guid id)
        {
            IRoleRepository repository = IoC.Container.Resolve<IRoleRepository>();
            IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>();
            GetRoleResponse response= repository.GetById<GetRoleResponse>(id.ToString());
            IList<Permission> rolerPermissions = perRepo.GetByRoleId(id.ToString());
            foreach (Permission per in rolerPermissions) {
                response.Permissions.Add(per.Id);
            }
            return response;
        }

        public void Update(UpdateRoleRequest request)
        {
            ValidationForUpdating(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IRoleRepository repository = IoC.Container.Resolve<IRoleRepository>(uow);
                Role existedRole = repository.GetById(request.Id.ToString(), "Permissions");
                existedRole.Name = request.Name;
                existedRole.Key = App.Common.Helpers.UtilHelper.ToKey(request.Name);
                existedRole.Description = request.Description;

                RemoveRemovedPermissions(existedRole, request, uow);
                AddAddedPermission(existedRole, request, uow);
                uow.Commit();
            }
        }
        private void AddAddedPermission(Role existedRole, UpdateRoleRequest request, IUnitOfWork uow)
        {
            if (request.Permissions.Count == 0) { return; }
            IList<Guid> existPers = existedRole.Permissions.Select(item => item.Id).ToList();
            IEnumerable<Guid> addedItems = request.Permissions.Except(existPers);
            IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>(uow);
            foreach (Guid item in addedItems)
            {
                Permission per = perRepo.GetById(item.ToString());
                existedRole.Permissions.Add(per);
            }
        }
        private void RemoveRemovedPermissions(Role existedRole, UpdateRoleRequest request, IUnitOfWork uow)
        {
            if (existedRole.Permissions.Count == 0) { return; }
            IList<Guid> existPers = existedRole.Permissions.Select(item => item.Id).ToList();
            IEnumerable<Guid> removedItems = existPers.Except(request.Permissions);
            foreach (Guid item in removedItems)
            {
                Permission per = existedRole.Permissions.FirstOrDefault(perItem => perItem.Id == item);
                existedRole.Permissions.Remove(per);
            }
        }
        private void ValidationForUpdating(UpdateRoleRequest request)
        {
            if (request.Id == null || request.Id == Guid.Empty)
            {
                throw new ValidationException("security.addOrUpdateRole.validation.idIsInvalid");
            }
            IRoleRepository roleRepository = IoC.Container.Resolve<IRoleRepository>();
            if (roleRepository.GetById(request.Id.ToString()) == null)
            {
                throw new ValidationException("security.addOrUpdateRole.validation.roleNotExist");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("security.addOrUpdateRole.validation.nameIsRequired");
            }
            string key = App.Common.Helpers.UtilHelper.ToKey(request.Name);
            Role roleByKey = roleRepository.GetByKey(key);
            if (roleByKey !=null && roleByKey.Id!=request.Id)
            {
                throw new ValidationException("security.addOrUpdateRole.validation.keyAlreadyExisted");
            }
        }
    }
}