using ECOMSYSTEM.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Web.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationDetails _quotationDetails;

        public QuotationController(IQuotationDetails quotationDetails)
        {
            _quotationDetails = quotationDetails;
        }

        public async Task<IActionResult> ViewQuotations()
        {
            var quotations = await _quotationDetails.GetAllQuotations();
            return View(quotations);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateStatus(long quotationId, string status)
        {
            var result = await _quotationDetails.UpdateQuotationStatus(quotationId, status);
            return Json(new { success = result });
        }
    }
}