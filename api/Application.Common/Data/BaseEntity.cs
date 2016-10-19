using System;
namespace App.Common.Data
{
    public abstract class BaseEntity: IBaseEntity<Guid>
    {
        public System.Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedDate = DateTime.UtcNow;
        }

        public BaseEntity(BaseEntity item)
        {
            this.Id = item.Id;
            this.CreatedDate = item.CreatedDate;
        }
    }
}
