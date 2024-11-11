using ECOMSYSTEM.Shared.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared.Interfaces
{
    public interface IQuotationRepository
    {
        
        Task<IEnumerable<Quotation>> GetAllQuotations();
        Task <bool> CreateQuotation(long itemId, long userId);

    }
}