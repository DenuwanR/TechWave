using ECOMSYSTEM.DataAccess.EntityModel;
using System.Numerics;

public class TblQuotation
{
    public long QuotationId { get; set; }
    public long ItemId { get; set; }  // Changed from OrderId

    public DateTime CreatedDate { get; set; }
    public long UserId { get; set; }

     
    // Navigation properties
    public virtual TblItemCart? ItemCart { get; set; }
    public virtual ICollection<TblSupplierQuote> TblSupplierQuotes { get; set; }
    public virtual TblUserRegistration User { get; set; }

}