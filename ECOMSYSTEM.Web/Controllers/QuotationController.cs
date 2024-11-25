//using ECOMSYSTEM.DataAccess.EntityModel;
//using ECOMSYSTEM.Shared.Interfaces;
//using ECOMSYSTEM.Shared.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Threading.Tasks;
//using ECOMSYSTEM.Repository.QuotationDetails;
//using ECOMSYSTEM.Shared;

//namespace ECOMSYSTEM.Web.Controllers
//{
//    public class QuotationController : Controller
//    {
//        private readonly IQuotationRepository _quotationRepository;

//        // Constructor injection of the repository
//        public QuotationController(IQuotationRepository quotationRepository)
//        {
//            _quotationRepository = quotationRepository;
//        }

//        // Action to display all quotations available for suppliers to view and submit quotes
//        public async Task<IActionResult> ViewQuotationsForSupplier()
//        {
//            try
//            {
//                var quotations = await _quotationRepository.GetQuotationsForSuppliers();
//                return View(quotations);  // Pass quotations to the view
//            }
//            catch (Exception ex)
//            {
//                TempData["Error"] = $"Error retrieving quotations: {ex.Message}";
//                return RedirectToAction("Index", "Home");
//            }
//        }

//        // Action to handle quotation creation (when user clicks on "Get Quotation")
//        public async Task<IActionResult> GetQuotation(long itemId)
//        {
//            try
//            {
//                // Retrieve the logged-in user's ID from the session
//                long userId = ApplicationSession.applicationUserId;

//                // Create a new quotation for the user and item
//                bool isSuccess = await _quotationRepository.CreateQuotation(itemId, userId);

//                TempData["Message"] = isSuccess ? "Quotation created successfully!" : "Failed to create quotation!";
//                return RedirectToAction("Index", "Home");
//            }
//            catch (Exception ex)
//            {
//                TempData["Error"] = $"Error creating quotation: {ex.Message}";
//                return RedirectToAction("Index", "Home");
//            }
//        }

//        // Action to handle supplier quote submission
//        [HttpPost]
//        public async Task<IActionResult> SubmitSupplierQuote(long quotationId, double quotationAmount)
//        {
//            try
//            {
//                // Retrieve the logged-in supplier's ID from the session
//                long? supplierId = ApplicationSession.SupplierId;

//                if (supplierId == null)
//                {
//                    TempData["Error"] = "Supplier ID not found in session.";
//                    return RedirectToAction("ViewQuotationsForSupplier");
//                }

//                // Add the supplier quote using the repository
//                bool isSuccess = await _quotationRepository.AddSupplierQuote(quotationId, supplierId.Value, quotationAmount);

//                TempData["Message"] = isSuccess ? "Quotation submitted successfully!" : "Failed to submit quotation!";
//                return RedirectToAction("ViewQuotationsForSupplier");
//            }
//            catch (Exception ex)
//            {
//                TempData["Error"] = $"Error submitting quotation: {ex.Message}";
//                return RedirectToAction("ViewQuotationsForSupplier");
//            }
//        }

//        // Action to display all the quotations a user has for a specific item
//        public async Task<IActionResult> ViewUserQuotations(long itemId)
//        {
//            try
//            {
//                var quotations = await _quotationRepository.GetQuotationsForItem(itemId);
//                return View(quotations); // Pass quotations to the view
//            }
//            catch (Exception ex)
//            {
//                TempData["Error"] = $"Error retrieving quotations: {ex.Message}";
//                return RedirectToAction("Index", "Home");
//            }
//        }


//    }
//}



using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Repository.QuotationDetails;
using ECOMSYSTEM.Repository.SupplierQuoteDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;


//using ECOMSYSTEM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Web.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationRepository _quotationRepository;
        //private readonly ECOM_WebContext _context;



        public QuotationController(IQuotationRepository quotationRepository/*ECOM_WebContext context*/)
        {
            _quotationRepository = quotationRepository;
            //_context = context;
        }

        public async Task<IActionResult> ViewQuotations()
        {
            var quotations = await _quotationRepository.GetAllQuotations();
            return View(quotations);
        }

        public async Task<IActionResult> SupplierDashboard()
        {
            var quotations = await _quotationRepository.GetAllQuotations();
            return View(quotations);
        }
    }
}
