using ECOMSYSTEM.Repository.SupplierQuoteDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using ECOMSYSTEM.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Web.Controllers
{
    [Route("SupplierQuote")]
    public class SupplierQuoteController : Controller
    {
        private readonly ISupplierQuoteDetails _supplierQuoteRepository;

        public SupplierQuoteController(ISupplierQuoteDetails supplierQuoteRepository)
        {
            _supplierQuoteRepository = supplierQuoteRepository;
        }


        [Route("UserView")]
        public async Task<IActionResult> UserView()
        {
            // Retrieve UserId from the session
            //long? userId = ApplicationSession.applicationUserId;
            var userId = ApplicationSession.applicationUserId; // Get user ID from session


            // If UserId is null, redirect to login or show an error
            if (userId == null)
            {
                Console.WriteLine("UserId is null");
                return RedirectToAction("Login", "Auth");

            }

            Console.WriteLine($"UserId: {userId}");
            // Fetch supplier quotes for the user
            var supplierQuotes = await _supplierQuoteRepository.GetSupplierQuoteDetails(userId);

            // Check if data exists
            if (supplierQuotes == null || !supplierQuotes.Any())
                return View("NoQuotesFound"); // Create a view to show "No Quotes Found"

            // Pass the data to the view
            return View(supplierQuotes);
        }



    }
}
