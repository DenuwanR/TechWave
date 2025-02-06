using ECOMSYSTEM.DataAccess.EntityModel;

public class TblQuotation
{
    public long QuotationId { get; set; }
    public long ItemId { get; set; }  // Changed from OrderId
    public long SupplierId { get; set; }

    public double QuotationAmount { get; set; }
    public string QuotationStatus { get; set; }
    public DateTime? CreatedDate { get; set; }
    public long? UserId { get; set; } // Nullable UserId property



    // Navigation properties
    public virtual TblItemCart Item { get; set; }
    public virtual TblUserRegistration Supplier { get; set; }
    public virtual TblUserRegistration User { get; set; } // Navigation property for User

}