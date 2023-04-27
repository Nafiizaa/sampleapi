using System;
using System.Collections.Generic;

namespace SimpleApiExcercise.Repositories.DAL.Models
{
    public partial class Shipment
    {
        public int ShipmentId { get; set; }
        public int OrderId { get; set; }
        public DateTime ShipmentDate { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
