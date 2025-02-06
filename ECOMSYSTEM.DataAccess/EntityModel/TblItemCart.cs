using System;
using System.Collections.Generic;

namespace ECOMSYSTEM.DataAccess.EntityModel
{
    public partial class TblItemCart
    {
        public TblItemCart()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public long ItemId { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public double? ItemPrice { get; set; }
        public int? ItemQty { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsInCart { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }

        public virtual TblProduct Product { get; set; } = null!;
        public virtual TblUserRegistration User { get; set; } = null!;
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        public virtual ICollection<TblQuotation> TblQuotation { get; set; }

    }
}
