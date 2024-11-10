using System;
using System.Collections.Generic;
using System.Numerics;

namespace ECOMSYSTEM.DataAccess.EntityModel
{
    public partial class TblOrder
    { 
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long ItemId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public double? OderValue { get; set; }
        public bool? IsActive { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsOrderAccept { get; set; }
        public long? SupplierId { get; set; }

        public virtual TblItemCart Item { get; set; } = null!;

        public virtual TblUserRegistration User { get; set; }  // Navigation property to the user



    }
}
