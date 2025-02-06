using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECOMSYSTEM.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IQuotationDetails _quotationService;
        private readonly ECOM_WebContext _context; 

        // Inject the services
        public SupplierController(IQuotationDetails quotationService, ECOM_WebContext context)
        {
            _quotationService = quotationService;
            _context = context;
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

        /// <summary>
        /// Saves the supplier's quotation amount to TblSupplierQuote.
        /// </summary>
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> SaveQuotationAmount(long quotationId, double quotationAmount)
        {
            try
            {
                var supplierId = ApplicationSession.SupplierId; // Get supplier ID from session
                var userId = ApplicationSession.applicationUserId; // Get user ID from session

                if (supplierId == null || userId == null)
                {
                    return BadRequest("Invalid session data.");
                }

                // Check if quotation exists
                var quotation = await _context.TblQuotations
                    .FirstOrDefaultAsync(q => q.QuotationId == quotationId);

                if (quotation == null)
                {
                    return NotFound("Quotation not found.");
                }

                // Create and save TblSupplierQuote
                var supplierQuote = new TblSupplierQuote
                {
                    QuotationId = quotationId,
                    SupplierId = supplierId.Value, // Get SupplierId from session
                    QuotationAmount = quotationAmount,
                    CreatedDate = DateTime.UtcNow
                };

                _context.TblSupplierQuotes.Add(supplierQuote);
                await _context.SaveChangesAsync();

                return Ok("Quotation amount submitted successfully.");
            }
            catch (Exception ex)
            {
                // Log exception and return error message
                //_logger.LogError(ex, "Error submitting quotation amount.");
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
