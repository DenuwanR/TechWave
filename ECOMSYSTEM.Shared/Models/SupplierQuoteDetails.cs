using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOMSYSTEM.Shared.Models
{
    public class SupplierQuoteDetails
    {
        [Key]
        public long SupplierQuoteId { get; set; }

        [ForeignKey("Quotation")]
        public long QuotationId { get; set; }

        [ForeignKey("Supplier")]
        public long SupplierId { get; set; }

        public double QuotationAmount { get; set; }
        public string? QuotationStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public string? ItemName { get; set; }

        [NotMapped]
        public string? ItemDescription { get; set; }

        [NotMapped]
        public string? UserName { get; set; }

        [NotMapped]
        public string? MobileNo { get; set; }

        // Navigation properties
        public virtual QuotationDetails? Quotation { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual ItemCartDetails? ItemCart { get; set; }

        public SupplierQuoteDetails() { }

        public SupplierQuoteDetails(
            long supplierQuoteId,
            long quotationId,
            long supplierId,
            double quotationAmount,
            string? quotationStatus,
            DateTime createdDate,
            string? itemName = null,
            string? itemDescription = null,
            string? userName = null,
            string? mobileNo = null)
        {
            SupplierQuoteId = supplierQuoteId;
            QuotationId = quotationId;
            SupplierId = supplierId;
            QuotationAmount = quotationAmount;
            QuotationStatus = quotationStatus;
            CreatedDate = createdDate;
            ItemName = itemName;
            ItemDescription = itemDescription;
            UserName = userName;
            MobileNo = mobileNo;
        }
    }
}
