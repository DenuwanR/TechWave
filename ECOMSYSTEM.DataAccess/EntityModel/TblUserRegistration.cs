using System;
using System.Collections.Generic;

namespace ECOMSYSTEM.DataAccess.EntityModel
{
    public partial class TblUserRegistration
    {
        public TblUserRegistration()
        {
            TblItemCarts = new HashSet<TblItemCart>();
            TblOrders = new HashSet<TblOrder>();
            TblQuotationSuppliers = new HashSet<TblQuotation>();
            TblQuotationUsers = new HashSet<TblQuotation>();
        }

        public long UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? MobileNo { get; set; }
        public bool? IsActive { get; set; }
        public int? UserType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? SupplierId { get; set; }

        public virtual ICollection<TblItemCart> TblItemCarts { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        public virtual ICollection<TblQuotation> TblQuotationSuppliers { get; set; }
        public virtual ICollection<TblQuotation> TblQuotationUsers { get; set; }
    }
}
