using App.Common.Data;

namespace App.Entity.Store
{
    public class OrderContact : BaseEntity
    {
        public OrderContact() : base() { }
        public OrderContact(string name, string email, string phone) : this()
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
