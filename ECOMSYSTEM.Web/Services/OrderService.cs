using ECOMSYSTEM.Repository.OderDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;

namespace ECOMSYSTEM.Web.Services
{
    public class OrderService : IOrderDetails
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productDetailsRepository">The product details repository.</param>
        public OrderService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public List<OrderDetails> GetAllOrders()
        {
            try
            {
                var result = _orderDetailsRepository.GetAllOrders();
                return result;
            }
            catch (Exception)
            {
                return new List<OrderDetails>();
            }
        }

        public List<OrderDetails> GetOrdersByUserId(long id)
        {
            try
            {
                var result = _orderDetailsRepository.GetOrdersByUserId(id);
                return result;
            }
            catch (Exception)
            {
                return new List<OrderDetails>();
            }
        }

        public List<OrderDetails> GetSupplierOrder(long? supplierId)
        {
            try
            {
                var result = _orderDetailsRepository.GetSupplierOrder(supplierId);
                return result;
            }
            catch (Exception)
            {
                return new List<OrderDetails>();
            }

        }

        public bool UpdateOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                var result = _orderDetailsRepository.UpdateOrderDetails(orderDetails);
                return result;
            }
            catch (Exception eX)
            {
                return false;
            }
        }

        public bool UpdateOrderStatus(OrderDetails orderDetails)
        {
            try
            {
                var result = _orderDetailsRepository.UpdateOrderStatus(orderDetails);
                return result;
            }
            catch (Exception eX)
            {
                return false;
            }
        }
    }
}
