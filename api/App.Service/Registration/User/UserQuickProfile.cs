using App.Common.Mapping;
using System;
using App.Entity.Registration;
using App.Common.Data;
using App.Entity.Common;

namespace App.Service.Registration.User
{
    public class UserQuickProfile: BaseEntity, IMappedFrom<App.Entity.Registration.User>
    {
        public UserQuickProfile(Entity.Registration.User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.LastLoggedInDate = user.LastLoggedInDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime LastLoggedInDate { get; set; }
        public string LanguageCode { get; set; }
    }
}
