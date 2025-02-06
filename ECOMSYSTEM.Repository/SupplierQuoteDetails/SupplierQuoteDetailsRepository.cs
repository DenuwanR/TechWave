using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ECOMSYSTEM.Repository.SupplierQuoteDetails
{
    public class SupplierQuoteDetailsRepository : ISupplierQuoteRepository
    {
        private readonly ECOM_WebContext _context;

        public SupplierQuoteDetailsRepository(ECOM_WebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ECOMSYSTEM.Shared.Models.SupplierQuoteDetails>> GetSupplierQuoteDetails(long userId)
        {
            var quotations = await _context.TblSupplierQuotes
                .Include(sq => sq.Quotation) // Include TblQuotation
                .ThenInclude(q => q.ItemCart) // Include TblItemCart through TblQuotation
                .Where(sq => sq.Quotation.UserId == userId) // Filter by UserId
                .Select(sq => new ECOMSYSTEM.Shared.Models.SupplierQuoteDetails
                {
                    SupplierQuoteId = sq.SupplierQuoteId,
                    QuotationId = sq.QuotationId,
                    SupplierId = sq.SupplierId ?? 0, // Handle nullable SupplierId
                    QuotationAmount = sq.QuotationAmount,
                    QuotationStatus = sq.QuotationStatus,
                    CreatedDate = sq.CreatedDate,
                    ItemName = sq.Quotation.ItemCart.ItemName,
                    ItemDescription = sq.Quotation.ItemCart.ItemDescription,
                    UserName = _context.TblUserRegistrations
                                    .Where(ur => ur.SupplierId == sq.SupplierId) // Match SupplierId from both tables
                                    .Select(ur => ur.Username)
                                    .FirstOrDefault(),
                    MobileNo = _context.TblUserRegistrations
                                    .Where(ur => ur.SupplierId == sq.SupplierId) // Match SupplierId from both tables
                                    .Select(ur => ur.MobileNo)
                                    .FirstOrDefault()
                })
                .ToListAsync();

            return quotations;
        }



    }
}
