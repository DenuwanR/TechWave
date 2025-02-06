using ECOMSYSTEM.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared.Interfaces
{
    public interface IQuotationDetails
    {
        Task<IEnumerable<Quotation>> GetAllQuotations();
        Task<bool> UpdateQuotationStatus(long id, string status);
    }
}