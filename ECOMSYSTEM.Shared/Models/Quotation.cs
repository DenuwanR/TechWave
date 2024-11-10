using System;
using System.Numerics;

namespace ECOMSYSTEM.Shared.Models
{
    public class Quotation
    {
        public long QuotationId { get; set; }
        public long ItemId { get; set; }
        public long? SupplierId { get; set; } // Nullable if a supplier is optional
        public string QuotationStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public long UserId { get; set; }


    }

}
