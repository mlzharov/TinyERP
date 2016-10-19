using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Registration;

namespace App.Repository.Registration
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User GetByEmail(string email);

        User GetByToken(string token);
    }
}
