using App.Common;
using App.Common.Data;
using App.Entity.ProductManagement;
using System;

namespace App.Entity.Store
{
    public class OrderItem : BaseEntity
    {
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime TransationDate { get; set; }
        public ItemStatus Status { get; set; }
        public string Comment { get; set; }
        /// <summary>
        /// called by EF only
        /// </summary>
        public OrderItem() : base()
        {
            this.TransationDate = DateTime.UtcNow;
            this.Status = ItemStatus.WaitForApproving;
        }

        public OrderItem(Product product, double quantity, decimal unitPrice, ItemStatus status, DateTime transactionDate, string comment) : base()
        {
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Status = status;
            this.TransationDate = transactionDate;
            this.Comment = comment;
            this.TotalPrice = (decimal)this.Quantity * this.UnitPrice;
        }
    }
}
