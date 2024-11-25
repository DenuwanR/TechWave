using System.Collections.Generic;
using System.Threading.Tasks;
using ECOMSYSTEM.Shared.Models;

namespace ECOMSYSTEM.Repository.SupplierQuoteDetails
{
    public interface ISupplierQuoteRepository
    {
        Task<IEnumerable<ECOMSYSTEM.Shared.Models.SupplierQuoteDetails>> GetSupplierQuoteDetails(long userId);
    }
}
