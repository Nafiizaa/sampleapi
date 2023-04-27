using System;
using System.Collections.Generic;

namespace SimpleApiExcercise.Repositories.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
