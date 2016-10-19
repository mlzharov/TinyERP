using App.Common;
using App.Common.Data;
using System;
using System.Collections.Generic;

namespace App.Entity.Store
{
    public class Order : BaseEntity
    {
        public OrderContact Contact { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Price { get; set; }
        public ItemStatus Status { get; set; }
        public DateTime TransationDate { get; set; }
        public double NumberOfItems { get; set; }
        public string Comment { get; set; }
        public Order() : base()
        {
            this.Items = new List<OrderItem>();
        }

        public void AddItem(OrderItem orderItem)
        {
            this.Items.Add(orderItem);
        }
    }
}
