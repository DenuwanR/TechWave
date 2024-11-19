using ECOMSYSTEM.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared
{
    public interface IQuotationDetails
    {
        Task<List<QuotationDetails>> GetAllQuotations();
    }
}
