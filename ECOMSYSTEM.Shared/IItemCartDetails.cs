using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared
{
    public interface IItemCartDetails
    {
        /// <summary>
        /// Adds the item cart.
        /// </summary>
        /// <param name="itemObject">The item object.</param>
        /// <returns></returns>
        ItemCartDetails AddItemCart(ItemCartDetails itemObject);

        /// <summary>
        /// Gets the items in cart.
        /// </summary>
        /// <param name="itemObject">The item object.</param>
        /// <returns></returns>
        List<ItemCartDetails> GetItemsInCart(long id);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool RemoveItem(long id);
    }
}
