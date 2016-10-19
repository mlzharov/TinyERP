using System;
using App.Service.Registration.User;
using App.Common;
using App.Common.Helpers;
using App.Common.Data;
using App.Common.Validation;
using App.Entity.Registration;
using App.Repository.Registration;
using App.Common.DI;
using System.Collections.Generic;

namespace App.Service.Impl.Registration
{
    class UserService : IUserService
    {
        public void CreateIfNotExist(IList<User> users)
        {
            if (users == null) { return; }
            using (IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IUserRepository userRepository = IoC.Container.Resolve<IUserRepository>(uow);
                foreach (User user in users)
                {
                    User existUser = userRepository.GetByEmail(user.Email);
                    if (existUser != null) { continue; }
                    userRepository.Add(user);
                }
                uow.Commit();
            }
        }

        public UserSignInResponse SignIn(UserSignInRequest request)
        {
            AuthenticationToken token;
            ValidateUserLoginRequest(request);
            User user;
            using (IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IUserRepository userRepository = IoC.Container.Resolve<IUserRepository>(uow);

                token = new App.Common.AuthenticationToken(Guid.NewGuid(), DateTimeHelper.GetAuthenticationTokenExpiredUtcDateTime());
                user = userRepository.GetByEmail(request.Email);

                user.Token = token.Value;
                user.TokenExpiredAfter = token.ExpiredAfter;
                userRepository.Update(user);
                uow.Commit();
            }
            UserQuickProfile profile = new UserQuickProfile(user);
            return new UserSignInResponse(token, profile);
        }

        private void ValidateUserLoginRequest(UserSignInRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("Common.InvalidRequest");
            }
            if (String.IsNullOrWhiteSpace(request.Email))
            {
                throw new ValidationException("Registration.SignIn.InvalidEmail");
            }
            if (String.IsNullOrWhiteSpace(request.Pwd))
            {
                throw new ValidationException("Registration.SignIn.InvalidPwd");
            }
            IUserRepository userRepository = IoC.Container.Resolve<IUserRepository>();
            User userProfile = userRepository.GetByEmail(request.Email);

            if (userProfile == null || EncodeHelper.EncodePassword(request.Pwd) != userProfile.Password)
            {
                throw new ValidationException("Registration.SignIn.InvalidEmailOrPwd");
            }

        }


        public void SignOut(string token)
        {
            using (IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IUserRepository userRepository = IoC.Container.Resolve<IUserRepository>(uow);
                User user = userRepository.GetByToken(token);
                if (user == null) { return; }
                user.Token = string.Empty;
                user.TokenExpiredAfter = DateTime.UtcNow;
                userRepository.Update(user);
                uow.Commit();
            }
        }
        public bool IsValidToken(string authenticationToken)
        {
            IUserRepository userRepository = IoC.Container.Resolve<IUserRepository>();
            User user = userRepository.GetByToken(authenticationToken);
            return user != null && !DateTimeHelper.IsExpired(user.TokenExpiredAfter);
        }
    }
}
