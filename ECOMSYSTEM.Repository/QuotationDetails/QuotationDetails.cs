//using ECOMSYSTEM.DataAccess.EntityModel;
//using ECOMSYSTEM.Shared.Interfaces;
//using ECOMSYSTEM.Shared.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq;
//using ECOMSYSTEM.DataAccess; // Add this line - adjust namespace based on where your DbContext is located

//namespace ECOMSYSTEM.Repository.QuotationDetails
//{
//    public class QuotationDetails : IQuotationDetails
//    {
//        private readonly ECOM_WebContext _dbContext = new ECOM_WebContext();

//        public QuotationDetails(ECOM_WebContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Quotation>> GetAllQuotations()
//        {
//            return await _context.TblQuotation
//                .Include(q => q.Supplier)
//                .Select(q => new Quotation
//                {
//                    QuotationId = q.QuotationId,
//                    Username = q.Supplier.Username,
//                    MobileNo = q.Supplier.MobileNo,
//                    QuotationAmount = q.QuotationAmount,
//                    QuotationStatus = q.QuotationStatus ?? "Pending"
//                })
//                .ToListAsync();
//        }

//        public async Task<bool> UpdateQuotationStatus(long id, string status)
//        {
//            var quotation = await _context.TblQuotation.FindAsync(id);
//            if (quotation == null) return false;

//            quotation.QuotationStatus = status;
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}