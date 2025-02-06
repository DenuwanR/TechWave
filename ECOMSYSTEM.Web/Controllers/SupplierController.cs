using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using ECOMSYSTEM.Web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ECOMSYSTEM.Web.Controllers
{
    public class SupplierController : Controller
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _config;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<SupplierController> _logger;
        private readonly IOrderDetails _applicationOrderService;
        public SupplierController(ILogger<SupplierController> logger,  IConfiguration config, IOrderDetails applicationOrderService)
        {
            _logger = logger;
            _config = config;
            _applicationOrderService = applicationOrderService;
        }

        public IActionResult SupplierHome()
        {
            var result = _applicationOrderService.GetAllOrders();
            return View(result);
        }

        public IActionResult SupplierOrderList()
        {
            long? supplierId = ApplicationSession.SupplierId;
            var result = _applicationOrderService.GetSupplierOrder(supplierId);
            return View(result);
        }

        public IActionResult UpdateOrder(OrderDetails orderDetails)
        {
            orderDetails.SupplierId = ApplicationSession.SupplierId;
            var result = _applicationOrderService.UpdateOrderDetails(orderDetails);
            if(result == true)
            {
                return Json(new
                {
                    success = true,
                    newUrl = Url.Action("Supplierhome", "Supplier")
                });

            }

            return Json(new
            {
                success = false
            });
        }

        public IActionResult UpdateOrderStatus(OrderDetails orderDetails)
        {
            orderDetails.SupplierId = ApplicationSession.SupplierId;
            var result = _applicationOrderService.UpdateOrderStatus(orderDetails);
            if (result == true)
            {
                return Json(new
                {
                    success = true,
                    newUrl = Url.Action("Supplierhome", "Supplier")
                });

            }

            return Json(new
            {
                success = false
            });
        }

        public IActionResult CancelOrder(OrderDetails orderDetails)
        {
            orderDetails.Type = "Cancel";
            var result = _applicationOrderService.UpdateOrderDetails(orderDetails);
            if (result == true)
            {
                return Json(new
                {
                    success = true,
                    newUrl = Url.Action("Supplierhome", "Supplier")
                });
            }

            return Json(new
            {
                success = false
            });
        }


    }
}
