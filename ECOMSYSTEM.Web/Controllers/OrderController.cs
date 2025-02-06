using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using ECOMSYSTEM.Web.Services;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;

namespace ECOMSYSTEM.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        /// <summary>
        /// The application product service
        /// </summary>
        private readonly IItemCartDetails _itemCartService;
        private readonly IOrderDetails _applicationOrderService;
        /// <summary>
        /// Gets the web host environment.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="itemCartDetailsService">The item cart details service.</param>
        /// <value>
        /// The web host environment.
        /// </value>
        public OrderController(ILogger<OrderController> logger, IItemCartDetails itemCartDetailsService, IOrderDetails applicationOrderService)
        {
            _logger = logger;
            _itemCartService = itemCartDetailsService;
            _applicationOrderService = applicationOrderService;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            long userId = ApplicationSession.applicationUserId;

            var result = _applicationOrderService.GetOrdersByUserId(userId);

            return View(result);
        }

        /// <summary>
        /// Items the cart.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ItemCart()
        {
            var totalItemPrice = 0.0;
            double? totlaPrice = 0.0;

            ItemCartDetails itemCartDetails = new ItemCartDetails();

            var items = _itemCartService.GetItemsInCart(ApplicationSession.applicationUserId);

            foreach (var item in items)
            {
                item.TotalPrice = 0;
                totalItemPrice = 0;

                totalItemPrice += item.ItemPrice;
                item.TotalPrice = totalItemPrice * item.ItemQty;

                totlaPrice = item.TotalPrice;
            }

            itemCartDetails.TotalAllItems = totlaPrice;

            var viewModel = new ItemCartModelView
            {
                Items = items,
                CartDetails = itemCartDetails
            };

            return View(items);
        }

        /// <summary>
        /// Adds the item cart.
        /// </summary>
        /// <param name="itemCartDetails">The item cart details.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddItemCart(ItemCartDetails itemCartDetails)
        {
            try
            {
                itemCartDetails.CreatedDate = DateTime.Now;
                itemCartDetails.UserId = ApplicationSession.applicationUserId;

                var result = _itemCartService.AddItemCart(itemCartDetails);
                if (result != null)
                {
                    return Json(new
                    {
                        success = true
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

        public ActionResult RemoveItem(ItemCartDetails itemDetails)
        {
            try
            {
                var result = _itemCartService.RemoveItem(itemDetails.ItemId);
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

        [HttpPost]
        public IActionResult SaveOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                orderDetails.CreatedDate = DateTime.Now;
                orderDetails.UserId = ApplicationSession.applicationUserId;

                var result = _applicationOrderService.UpdateOrderDetails(orderDetails);
                if (result == true)
                {
                    SendMailToCustomer(orderDetails);
                    return Json(new
                    {
                        success = true
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

        public void SendMailToCustomer(OrderDetails orderDetails)
        {
            // Gmail SMTP server details
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            // Gmail account credentials
            string emailFrom = "denuwanmadhubhashana@gmail.com";
            string password = "cwyu ylyo hmtr bfus";

            // Recipient email address
            string emailTo = orderDetails.Email;

            // Email subject and body
            string subject = "Receipt - Tech Wave";
            //string body = "Thank you for your order." + " Order Amount :" + orderDetails.OderValue;

            // Create the email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", emailFrom)); // Updated this line
            message.To.Add(new MailboxAddress("", emailTo)); // Updated this line
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = GenerateReceiptBody(orderDetails)
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                // Connect to the SMTP server
                client.Connect(smtpServer, smtpPort, false);

                // Authenticate with the server
                client.Authenticate(emailFrom, password);

                // Send the email
                client.Send(message);

                // Disconnect from the server
                client.Disconnect(true);
            }

            Console.WriteLine("Email sent successfully.");
        }

        string GenerateReceiptBody(OrderDetails orderDetails)
        {
            string body = $@"
        <html>
        <body>
            <h2>Receipt | Tech Wave </h2>
            <p>Dear {orderDetails.Name},</p>
            <p>Thank you for your order. Your order with reference number 00{orderDetails.ItemId} has been processed successfully.</p>
            <p>Date : {orderDetails.CreatedDate}</p>
            <p>Thank you! Stay tune for the best quotation for your dream PC!</p>
            <p>Sincerely,</p>
            <p>Tech Wave Team</p>

            <h4>Contact Us</h4>
            <table>
                <tr>
                    <td>Email:</td>
                    <td>info@techwave.com</td>
                </tr>
                <tr>
                    <td>Whatsapp (Text only):</td>
                    <td>+94 77 55 55 666</td>
                </tr>
            </table>

        </body>
        </html>";

            return body;
        }
    }
}
