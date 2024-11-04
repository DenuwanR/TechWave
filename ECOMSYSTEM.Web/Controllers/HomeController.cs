using Microsoft.AspNetCore.Mvc;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Web.Models;
using System.Diagnostics;
using ECOMSYSTEM.Shared.Models;
using OfficeOpenXml.Sorting;

namespace ECOMSYSTEM.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMyInterface _myService;
        /// <summary>
        /// The application product service
        /// </summary>
        private readonly IProductDetails _applicationProductService;
        /// <summary>
        /// Gets the web host environment.
        /// </summary>
        /// <value>
        /// The web host environment.
        /// </value>
        /// 
        public HomeController(ILogger<HomeController> logger, IProductDetails productDetailsService, IMyInterface myService)
        {
            _logger = logger;
            _applicationProductService = productDetailsService;
            _myService = myService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string category, string subcategory)
        {
            if (category != "null" && subcategory != "null")
            {
                var result = _applicationProductService.GetSelectedProducts(category, subcategory);
                return View(result);

            }
            else
            {
                var result = _applicationProductService.GetAllProducts();
                return View(result);
            }          
        }

        /// <summary>
        /// GetSelectedProducts.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetSelectedProducts(string category, string subcategory)
        {
            var result = _applicationProductService.GetSelectedProducts(category, subcategory);
            return View(result);
        }

        //public IActionResult SelectedProducts()
        //{
        //    return View();
        //}

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productDetails">The product details.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetProductById(ProductDetails productDetails)
        {
            try
            {
                var result = _applicationProductService.GetProductById(productDetails.ProductId);
                if (result != null)
                {
                    return Json(new
                    {
                        success = true,
                        response = result
                    });
                }

                return Json(new
                {
                    success = false
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false
                });
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public string getKey()
        {
            Guid id = Guid.NewGuid();
            return _myService.getSecurityKey(id.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}