//using ECOMSYSTEM.Shared.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace ECOMSYSTEM.Shared.Interfaces
//{
//    public interface IQuotationRepository
//    {
//        // Existing methods
//        Task<bool> CreateQuotation(long itemId, long userId);

//        // New method to add a supplier quote
//        Task<bool> AddSupplierQuote(long quotationId, long? supplierId, double quotationAmount);

//        // New method to retrieve quotations available for suppliers to quote on
//        Task<IEnumerable<QuotationDetails>> GetQuotationsForSuppliers();

//        // New method to retrieve quotations for a specific item
//        Task<IEnumerable<QuotationDetails>> GetQuotationsForItem(long itemId);

//        // New method to place an order based on the selected quotation
//        //Task<bool> PlaceOrder(long quotationId, long userId);
//    }
//}
