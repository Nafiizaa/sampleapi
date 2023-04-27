using System;
using System.Collections.Generic;

namespace SimpleApiExcercise.Repositories.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
