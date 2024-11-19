using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOMSYSTEM.Shared.Models
{
    public class SupplierQuoteDetails
    {
        [Key]
        public long SupplierQuoteId { get; set; }  // Primary key for supplier's quote

        [ForeignKey("Quotation")]
        public long QuotationId { get; set; }  // User's quotation

        [ForeignKey("Supplier")]
        public long SupplierId { get; set; }  // Supplier submitting the quote

        public double QuotationAmount { get; set; }  // Amount quoted by the supplier
        public string? QuotationStatus { get; set; }  // Status (e.g., Pending, Accepted)
        public DateTime CreatedDate { get; set; }  // Creation timestamp

        // Navigation properties
        public virtual QuotationDetails Quotation { get; set; }
    }
}
