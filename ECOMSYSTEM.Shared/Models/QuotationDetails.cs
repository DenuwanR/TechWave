// First file: QuotationDetails.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOMSYSTEM.Shared.Models
{
    public class QuotationDetails
    {
        [Key]
        public long QuotationId { get; set; }
        public long ItemId { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        // Making these properties read-write instead of computed
        [NotMapped]
        public string? ItemName { get; set; }
        [NotMapped]
        public string? ItemDescription { get; set; }
        [NotMapped]
        public string? MobileNo { get; set; }

        // Navigation properties
        public virtual ItemCartDetails? ItemCart { get; set; }
        public virtual ApplicationUser? User { get; set; }

        // Default constructor for EF Core
        public QuotationDetails() { }

        // Constructor with all parameters
        public QuotationDetails(
            long quotationId,
            long itemId,
            long userId,
            DateTime createdDate,
            string? itemName = null,
            string? itemDescription = null,
            string? mobileNo = null)
        {
            QuotationId = quotationId;
            ItemId = itemId;
            UserId = userId;
            CreatedDate = createdDate;
            ItemName = itemName;
            ItemDescription = itemDescription;
            MobileNo = mobileNo;
        }
    }
}
