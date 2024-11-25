using System.Collections.Generic;
using System.Threading.Tasks;
using ECOMSYSTEM.Repository.SupplierQuoteDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;

namespace ECOMSYSTEM.Web.Services
{
    public class SupplierQuoteService : ISupplierQuoteDetails
    {
        private readonly ISupplierQuoteRepository _supplierQuoteRepository;

        public SupplierQuoteService(ISupplierQuoteRepository supplierQuoteRepository)
        {
            _supplierQuoteRepository = supplierQuoteRepository;
        }

        public async Task<List<SupplierQuoteDetails>> GetSupplierQuoteDetails(long userId)
        {
            var quotations = await _supplierQuoteRepository.GetSupplierQuoteDetails(userId);
            return quotations != null ? new List<SupplierQuoteDetails>(quotations) : new List<SupplierQuoteDetails>();
        }
    }
}
