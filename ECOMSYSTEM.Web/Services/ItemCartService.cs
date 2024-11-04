using ECOMSYSTEM.Repository.ApplicationUsers;
using ECOMSYSTEM.Repository.ItemDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;

namespace ECOMSYSTEM.Web.Services
{
    public class ItemCartService : IItemCartDetails
    {
        private readonly IItemCartDetailsRepository _itemCartRepository;

        public ItemCartService(IItemCartDetailsRepository itemCartRepository)
        {
            _itemCartRepository = itemCartRepository;
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
                var result = _itemCartRepository.AddItemCart(itemObject);
                return result;
            }
            catch (Exception eX)
            {
                return new ItemCartDetails();
            }
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ItemCartDetails> GetItemsInCart(long id)
        {
            try
            {
                var result = _itemCartRepository.GetItemsInCart(id);
                return result;
            }
            catch (Exception)
            {
                return new List<ItemCartDetails>();
            }
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool RemoveItem(long id)
        {
            try
            {
                var result = _itemCartRepository.RemoveItem(id);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
