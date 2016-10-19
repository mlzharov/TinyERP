using System.Collections.Generic;
using App.Entity.Registration;

namespace App.Service.Registration.User
{
    public interface IUserService
    {
        UserSignInResponse SignIn(UserSignInRequest request);
        void CreateIfNotExist(IList<Entity.Registration.User> users);

        void SignOut(string token);

        bool IsValidToken(string authenticationToken);
    }
}
