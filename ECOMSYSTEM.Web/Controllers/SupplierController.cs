using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IQuotationDetails _quotationService;

        public SupplierController(IQuotationDetails quotationService)
        {
            _quotationService = quotationService;
        }

        /// <summary>
        /// Displays the Supplier Dashboard with data for suppliers.
        /// </summary>
        public async Task<IActionResult> SupplierHome()
        {
            try
            {
                // Fetch quotations for the supplier dashboard
                var quotations = await _quotationService.GetAllQuotations();
                return View(quotations); // Pass the data to SupplierHome.cshtml
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading supplier data: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
