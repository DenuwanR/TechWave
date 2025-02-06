using System.Collections.Generic;
using System.Threading.Tasks;
using ECOMSYSTEM.Shared.Models;

namespace ECOMSYSTEM.Shared
{
    public interface ISupplierQuoteDetails
    {
        Task<List<SupplierQuoteDetails>> GetSupplierQuoteDetails(long userId);
    }
}
