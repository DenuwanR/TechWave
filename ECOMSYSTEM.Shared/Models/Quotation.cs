using System;

namespace ECOMSYSTEM.Shared.Models
{
    public class Quotation
    {
        public long QuotationId { get; set; }
 
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public double QuotationAmount { get; set; }
        public string QuotationStatus { get; set; }

      

        // You might want to add additional display or computed properties
        public string FormattedAmount => QuotationAmount.ToString("C");
        public string StatusBadgeClass => QuotationStatus?.ToLower() switch
        {
            "accepted" => "badge-success",
            "declined" => "badge-danger",
            "pending" => "badge-warning",
            _ => "badge-secondary"
        };
    }
}