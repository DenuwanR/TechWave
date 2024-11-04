using AutoMapper;
using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared;
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
    public class ItemCartDetailsRepository : IItemCartDetailsRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ECOM_WebContext _dbContext = new ECOM_WebContext();
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserRepository" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public ItemCartDetailsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Adds the item cart.
        /// </summary>
        /// <param name="itemObject">The item object.</param>
        /// <returns></returns>
        public ItemCartDetails AddItemCart(ItemCartDetails itemObject)
        {
            try
            {
                var MappedObject = _mapper.Map<TblItemCart>(itemObject);

                _dbContext.TblItemCarts.Add(MappedObject);
                var result = _dbContext.SaveChanges();

                itemObject.ItemId = MappedObject.ItemId;
                if (result > 0) return itemObject;

                return new ItemCartDetails();

            }
            catch (Exception eX)
            {
                return new ItemCartDetails(); ;
            }

        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public List<ItemCartDetails> GetItemsInCart(long id)
        {
            try
            {
                var result = _dbContext.TblItemCarts.Where(u => u.UserId == id && u.IsInCart == true && u.IsActive == true).ToList();
                var mappedUsers = _mapper.Map<List<ItemCartDetails>>(result);
                return mappedUsers;
            }
            catch (Exception eX)
            {
                return new List<ItemCartDetails>();
            }
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public bool RemoveItem(long id)
        {
            try
            {
                var item = _dbContext.TblItemCarts.Where(u => u.ItemId == id && u.IsActive == true).SingleOrDefault();
                if (item == null) { return false; }
                //item.IsActive = false;
                //item.IsInCart = false;
                _dbContext.TblItemCarts.Remove(item);
                var result = _dbContext.SaveChanges();
                //var mappedobject = _mapper.Map<ItemCartDetails>(item);
                //if (mappedobject != null) return true;
                if (result > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception eX)
            {
                return false;
            }
        }
    }
}

