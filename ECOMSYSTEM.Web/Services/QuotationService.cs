using ECOMSYSTEM.Repository.QuotationDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Web.Services
{
    public class QuotationService : IQuotationDetails
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationService(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        /// <summary>
        /// Fetches all quotations for the dashboard.
        /// </summary>
        /// <returns>List of quotation details.</returns>
        public async Task<List<QuotationDetails>> GetAllQuotations()
        {
            var quotations = await _quotationRepository.GetAllQuotations();
            return quotations != null ? new List<QuotationDetails>(quotations) : new List<QuotationDetails>();
        }

        /// <summary>
        /// Creates a new quotation entry.
        /// </summary>
        /// <param name="itemId">The item ID for which the quotation is being created.</param>
        /// <param name="userId">The user ID requesting the quotation.</param>
        /// <returns>True if creation is successful, otherwise false.</returns>
        public async Task<bool> CreateQuotation(long itemId, long userId)
        {
            return await _quotationRepository.CreateQuotation(itemId, userId);
        }
    }
}
