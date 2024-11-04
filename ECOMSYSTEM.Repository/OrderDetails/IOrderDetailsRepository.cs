using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.OderDetails
{
    public interface IOrderDetailsRepository
    {
        List<OrderDetails> GetAllOrders();
        List<OrderDetails> GetSupplierOrder(long? supplierId);
        bool UpdateOrderDetails(OrderDetails orderDetails);
        bool UpdateOrderStatus(OrderDetails orderDetails);
        List<OrderDetails> GetOrdersByUserId(long id);
    }
}
