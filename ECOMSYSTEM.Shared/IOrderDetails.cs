using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared
{
    public interface IOrderDetails
    {
        List<OrderDetails> GetAllOrders();
        List<OrderDetails> GetOrdersByUserId(long id);
        List<OrderDetails> GetSupplierOrder(long? supplierId);
        bool UpdateOrderDetails(OrderDetails orderDetails);
        bool UpdateOrderStatus(OrderDetails orderDetails);
    }
}
