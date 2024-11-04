using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ECOMSYSTEM.Web.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _config;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AdminController> _logger;
        /// <summary>
        /// The application user service
        /// </summary>
        private readonly IApplicatioUser _applicationUserService;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IOrderDetails _applicationOrderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="applicatioUserService">The applicatio user service.</param>
        /// <param name="config">The configuration.</param>
        public AdminController(ILogger<AdminController> logger, IApplicatioUser applicatioUserService, IProductDetails productDetailsService, IConfiguration config, IWebHostEnvironment webHostEnvironment, IOrderDetails applicationOrderService)
        {
            _logger = logger;
            _applicationUserService = applicatioUserService;
            _applicationProductService = productDetailsService;
            _config = config;
            _webHostEnvironment = webHostEnvironment;
            _applicationOrderService = applicationOrderService;           
        }

        /// <summary>
        /// Admins the home.
        /// </summary>
        /// <returns></returns>
        public IActionResult AdminHome()
        {
            AdminDashboadModel adminDashboadModel = new AdminDashboadModel();
            adminDashboadModel.SupplierCount = 0;
            adminDashboadModel.UserCount = 0;
            adminDashboadModel.ProductCount = 0;
            adminDashboadModel.OrderCount = 0;

            var users = _applicationUserService.GetAllUsers();
            if(users.Count > 0)
            {
                foreach (var user in users)
                {
                    if(user.UserType == 1)
                    {
                        adminDashboadModel.UserCount++;
                    }else if(user.UserType == 2)
                    {
                        adminDashboadModel.SupplierCount++;
                    }
                }
            }

            adminDashboadModel.OrderCount = _applicationOrderService.GetAllOrders().Count;
            adminDashboadModel.ProductCount= _applicationProductService.GetAllProducts().Count;

            return View(adminDashboadModel);
        }

        /// <summary>
        /// Views the user list.
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewUserList()
        {
            var result = _applicationUserService.GetAllUsers();
            return View(result);
        }

        public IActionResult ExportToExcel()
        {
            // Set the license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Get data to export to Excel
            var data = _applicationUserService.GetAllUsers(); // Replace with your own data retrieval logic

            // Create a new Excel package
            using (ExcelPackage package = new ExcelPackage())
            {
                // Create a new worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Set header names
                worksheet.Cells[1, 1].Value = "User Id";
                worksheet.Cells[1, 2].Value = "User Name";
                worksheet.Cells[1, 3].Value = "User Type";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Mobile No";
                worksheet.Cells[1, 6].Value = "Address";
                worksheet.Cells[1, 7].Value = "Is Active";
                worksheet.Cells[1, 8].Value = "Created Date";
      
                // Apply formatting to header cells
                using (var range = worksheet.Cells[1, 1, 1, 8])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Populate the worksheet with data
                int rowIndex = 2; // Start from row 2 for data

                foreach (var item in data)
                {
                    worksheet.Cells[rowIndex, 1].Value = item.UserId;
                    worksheet.Cells[rowIndex, 2].Value = item.Username;
                    worksheet.Cells[rowIndex, 3].Value = item.UserType;
                    worksheet.Cells[rowIndex, 4].Value = item.Email;
                    worksheet.Cells[rowIndex, 5].Value = item.MobileNo;
                    worksheet.Cells[rowIndex, 6].Value = item.Address;
                    worksheet.Cells[rowIndex, 7].Value = item.IsActive;
                    worksheet.Cells[rowIndex, 8].Value = item.CreatedDate;

                    rowIndex++;
                }

                // Prepare the Excel package for download
                var memoryStream = new MemoryStream();
                package.SaveAs(memoryStream);
                memoryStream.Position = 0;

                // Return the Excel file for download
                return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserDetails.xlsx");
            }
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <returns></returns>
        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult AddSuppliers()
        {
            return View();
        }

        public IActionResult ViewOders()
        {
            var result = _applicationOrderService.GetAllOrders();
            return View(result);
        }

        /// <summary>
        /// Registers the specified application user.
        /// </summary>
        /// <param name="applicationUser">The application user.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(ApplicationUser applicationUser)
        {
            applicationUser.CreatedDate = DateTime.Now;
            applicationUser.UserType = 2;
            var user = _applicationUserService.RegisterUser(applicationUser);

            if (user.UserId != 0 && user.Email != null)
            {
                return Json(new
                {
                    success = true
                });
            }

            return Json(new
            {
                success = false,
            });
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="productDetailsObj">The product details object.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProduct(ProductDetails productDetailsObj)
        {
            productDetailsObj.CreatedDate = DateTime.Now;
            productDetailsObj.IsActive = true;
            productDetailsObj.ProductSubCategoryId = int.Parse(productDetailsObj.ProductCategoryId.ToString() + productDetailsObj.ProductSubCategoryId.ToString());

            if(productDetailsObj.ProductId == 0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(productDetailsObj.ImageFile.FileName);
                string extention = Path.GetExtension(productDetailsObj.ImageFile.FileName);

                productDetailsObj.ImageName = fileName + extention;
                string path = Path.Combine(wwwRootPath + "/Image", productDetailsObj.ImageName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    productDetailsObj.ImageFile.CopyTo(fileStream);
                }

                var freshResult = _applicationProductService.addProductDetails(productDetailsObj);
                return View();
            }

            var editResult = _applicationProductService.addProductDetails(productDetailsObj);
            if(editResult != null)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });

        }

        /// <summary>
        /// Views the product.
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewProduct()
        {
            var result = _applicationProductService.GetAllProducts();
            return View(result);
        }

        /// <summary>Deletes the salary scale.</summary>
        /// <param name="salaryscale">The salaryscale.</param>
        [HttpPost]
        public ActionResult DeleteProduct(ProductDetails productDetails)
        {
            try
            {
                var result = _applicationProductService.DeleteProduct(productDetails.ProductId);
                if (result == true)
                {
                    return Json(new { success = true });
                }

                return Json(new { success = false });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

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
    }
}
