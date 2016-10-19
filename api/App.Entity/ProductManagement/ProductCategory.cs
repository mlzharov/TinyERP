using App.Common;
using App.Common.Data;
using System;

namespace App.Entity.ProductManagement
{
    public class ProductCategory : BaseContent
    {
        public Guid ParentId { get; set; }
        public ProductCategory(){}
        public ProductCategory(string name, ItemStatus status, string description, Guid parentId)
        {
            this.Name = name;
            this.Status = status;
            this.Description = description;
            this.ParentId = parentId;
        }
        public ItemStatus Status { get; set; }
    }
}
