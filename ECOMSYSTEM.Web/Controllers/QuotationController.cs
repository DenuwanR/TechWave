using ECOMSYSTEM.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Web.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationRepository _quotationDetails;

        public QuotationController(IQuotationRepository quotationDetails)
        {
            _quotationDetails = quotationDetails;
        }

        public async Task<IActionResult> ViewQuotations()
        {
            var quotations = await _quotationDetails.GetAllQuotations();
            return View(quotations);
        }
      
    }
}