using App.Common;
using App.Common.Data;
using App.Entity.ProductManagement;
using System.Collections.Generic;

namespace App.Entity.Store
{
    public class Store: BaseEntity
    {
        /// <summary>
        /// For EF only
        /// </summary>
        public Store(){
            this.Products = new List<Product>();
        }
        public Store(string name, ItemStatus status, string description): this()
        {
            this.Name = name;
            this.Description = description;
            this.Status = status;
        }

        public string Name { get; set; }
        public ItemStatus Status { get; set; }
        public string Description { get; set; }
        public StoreAccount Owner { get; set; }
        public IList<App.Entity.ProductManagement.Product> Products { get; set; }
    }
}
