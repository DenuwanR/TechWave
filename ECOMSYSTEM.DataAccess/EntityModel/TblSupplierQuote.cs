using System;

namespace ECOMSYSTEM.DataAccess.EntityModel
{
    public class TblSupplierQuote
    {
        public long SupplierQuoteId { get; set; }  // Primary key for supplier's quote
        public long QuotationId { get; set; }  // User (Customer) who requested the quotation
        public long? SupplierId { get; set; }  // Supplier submitting the quote
        public double QuotationAmount { get; set; }  // The amount quoted by the supplier
        public string? QuotationStatus { get; set; }  // The status of the quotation (e.g., Pending, Accepted)
        public DateTime CreatedDate { get; set; }  // Timestamp when the quotation was created

        // Navigation properties
        public virtual TblQuotation? Quotation { get; set; }  // Navigation to TblQuotation (via ItemId and UserId)
        public virtual TblUserRegistration? User { get; set; }  // Navigation to TblUserRegistration (Customer)
        public virtual TblUserRegistration? Supplier { get; set; }  // Navigation to TblQuotation (via ItemId and UserId)
    }
}
