using App.Common;
using App.Common.Data;
using System;

namespace App.Entity.Store
{
    public class StoreAccount : BaseEntity
    {
        //EF call to this only
        public StoreAccount(): base()
        {
        }
        public StoreAccount(string name, string email, string userName, ItemStatus status, Guid photo, string description) : base()
        {
            this.Name = name;
            this.Email = email;
            this.UserName = userName;
            this.Status = status;
            this.Photo = photo == null ? Guid.Empty : photo;
            this.Description = description;
            this.Status = ItemStatus.WaitForActivating;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public ItemStatus Status { get; set; }
        public string Description { get; set; }
        public Guid Photo { get; set; }
    }
}
