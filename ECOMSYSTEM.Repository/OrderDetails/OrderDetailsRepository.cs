using AutoMapper;
using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Repository.OderDetails;
using ECOMSYSTEM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.ItemDetails
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ECOM_WebContext _dbContext = new ECOM_WebContext();
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailsRepository" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public OrderDetailsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<OrderDetails> GetAllOrders()
        {
            try
            {
                var Orders = _dbContext.TblOrders.ToList();
                var mappedOrders = _mapper.Map<List<OrderDetails>>(Orders);
                foreach (OrderDetails Item in mappedOrders)
                {
                    var itemDetails = _dbContext.TblItemCarts.Where(u => u.ItemId == Item.ItemId).FirstOrDefault();
                    Item.ItemDescription = itemDetails.ItemDescription;
                    Item.ItemName = itemDetails.ItemName;
                }
               
                return mappedOrders;
            }
            catch (Exception eX)
            {
                return new List<OrderDetails>();
            }
        }

        public List<OrderDetails> GetOrdersByUserId(long id)
        {
            try
            {
                var item = new TblItemCart();
                var Orders = _dbContext.TblOrders.Where(u => u.UserId == id && u.IsActive == true).ToList();
                var mappedOrders = _mapper.Map<List<OrderDetails>>(Orders);
                foreach (var o in mappedOrders)
                {
                    item = _dbContext.TblItemCarts.Where(u => u.ItemId == o.ItemId).SingleOrDefault();
                    o.ItemName = item.ItemName;
                    o.ItemDescription = item.ItemDescription;
                    o.ItemQty = item.ItemQty;
                }
                return mappedOrders;
            }
            catch (Exception eX)
            {
                return new List<OrderDetails>();
            }
        }

        public List<OrderDetails> GetSupplierOrder(long? supplierId)
        {
            try
            {
                if (supplierId != null)
                {
                    var Orders = _dbContext.TblOrders.Where(u => u.SupplierId == supplierId && u.IsOrderAccept == true).ToList();
                    var mappedOrders = _mapper.Map<List<OrderDetails>>(Orders);
                    return mappedOrders;
                }

                return new List<OrderDetails>();
            }
            catch (Exception eX)
            {
                return new List<OrderDetails>();
            }
        }

        public bool UpdateOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                if (orderDetails.OrderId > 0)
                {
                    var result = _dbContext.TblOrders.Where(u => u.OrderId == orderDetails.OrderId && u.UserId == orderDetails.UserId).FirstOrDefault();
                    if (result == null) { return false; }
                    var mappedobject = _mapper.Map<OrderDetails>(result);

                    if (orderDetails.Type == "Cancel")
                    {
                        result.IsOrderAccept = false;
                        result.OrderStatus = "NeedToBuy";
                        result.ModifiedDate = DateTime.Now;
                        result.SupplierId = null;
                        _dbContext.SaveChanges();
                        if (mappedobject != null)
                        {
                            return true;
                        }
                        return false;
                    }

                    result.IsOrderAccept = true;
                    result.OrderStatus = "OrderAccepted";
                    result.ModifiedDate = DateTime.Now;
                    result.SupplierId = orderDetails.SupplierId;
                    _dbContext.SaveChanges();
                    if (mappedobject != null) return true;
                    return false;
                }
                else
                {
                    var item = _dbContext.TblItemCarts.Where(u => u.ItemId == orderDetails.ItemId).FirstOrDefault();

                    if (item != null)
                    {
                        orderDetails.IsActive = true;
                        orderDetails.OrderStatus = "NeetToBuy";
                        orderDetails.OderValue = item.ItemPrice;
                        orderDetails.IsOrderAccept = false;
                        orderDetails.ModifiedDate = DateTime.Now;
                    }
                    else
                    {
                        return false;
                    }

                    var MappedObject = _mapper.Map<TblOrder>(orderDetails);
                    _dbContext.TblOrders.Add(MappedObject);
                    var result = _dbContext.SaveChanges();
                    orderDetails.OrderId = MappedObject.OrderId;
                    if (result > 0)
                    {
                        var removeitem = _dbContext.TblItemCarts.Where(u => u.ItemId == item.ItemId && u.IsActive == true).SingleOrDefault();
                        if (removeitem == null) { return false; }
                        removeitem.IsActive = false;
                        removeitem.IsInCart = false;
                        _dbContext.SaveChanges();
                        return true;
                    }
                    return false;
                }
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
                var result = _dbContext.TblOrders.Where(u => u.OrderId == orderDetails.OrderId && u.SupplierId == orderDetails.SupplierId && u.IsOrderAccept == true).FirstOrDefault();
                if (result == null) { return false; }
                result.IsOrderAccept = true;
                result.OrderStatus = orderDetails.OrderStatus;
                result.ModifiedDate = DateTime.Now;
                result.SupplierId = orderDetails.SupplierId;
                _dbContext.SaveChanges();
                var mappedobject = _mapper.Map<OrderDetails>(result);
                if (mappedobject != null) return true;
                return false;
            }
            catch (Exception eX)
            {
                return false;
            }
        }
    }
}

