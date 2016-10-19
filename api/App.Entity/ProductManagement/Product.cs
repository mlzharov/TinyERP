using App.Common.Data;
using System;
namespace App.Entity.ProductManagement
{
    public class Product : BaseContent
    {
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Store.Store Store { get; set; }
        public string Attachments { get; set; }

        public Product() : base()
        {
            this.FromDate = null;
            this.ToDate = null;
        }

    }
}
