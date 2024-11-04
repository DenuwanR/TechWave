using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.ProductsDetails
{
    public interface IProductDetailsRepository
    {
        /// <summary>
        /// Adds the product details.
        /// </summary>
        /// <param name="userObject">The user object.</param>
        /// <returns></returns>
        ProductDetails AddProductDetails(ProductDetails userObject);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        List<ProductDetails> GetAllProducts();

        List<ProductDetails> GetSelectedProducts(string category, string subcategory);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool DeleteProduct(long id);

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ProductDetails GetProductById(long id);
    }
}
