using System;
using System.Collections.Generic;

namespace ECOMSYSTEM.DataAccess.EntityModel
{
    public partial class TblQuotation
    {
        public long QuotationId { get; set; }
        public long ItemId { get; set; }
        public long? SupplierId { get; set; }
        public double? QuotationAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UserId { get; set; }

        public virtual TblItemCart Item { get; set; } = null!;
        public virtual TblUserRegistration? Supplier { get; set; }
        public virtual TblUserRegistration? User { get; set; }
    }
}
