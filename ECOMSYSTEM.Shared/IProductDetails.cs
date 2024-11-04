using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared
{
    public interface IProductDetails
    {
        /// <summary>
        /// Adds the product details.
        /// </summary>
        /// <param name="productObject">The product object.</param>
        /// <returns></returns>
        ProductDetails addProductDetails(ProductDetails productObject);

        /// <summary>
        /// Gets all products.
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
