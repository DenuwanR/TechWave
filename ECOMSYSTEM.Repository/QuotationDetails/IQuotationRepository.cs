using ECOMSYSTEM.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.QuotationDetails
{
    public interface IQuotationRepository
    {
        Task<bool> CreateQuotation(long itemId, long userId);
        Task<IEnumerable<ECOMSYSTEM.Shared.Models.QuotationDetails>> GetAllQuotations();
        //Task<bool> AddSupplierQuote(long quotationId, long? supplierId, double quotationAmount);
        //Task<IEnumerable<ECOMSYSTEM.Shared.Models.QuotationDetails>> GetQuotationsForSuppliers();
    }
}
