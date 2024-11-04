using ECOMSYSTEM.Repository.ApplicationUsers;
using ECOMSYSTEM.Repository.ProductsDetails;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;

namespace ECOMSYSTEM.Web.Services
{
    public class ProductService : IProductDetails
    {
        /// <summary>
        /// The product details repository
        /// </summary>
        private readonly IProductDetailsRepository _productDetailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productDetailsRepository">The product details repository.</param>
        public ProductService(IProductDetailsRepository productDetailsRepository)
        {
            _productDetailsRepository = productDetailsRepository;
        }

        /// <summary>
        /// Adds the product details.
        /// </summary>
        /// <param name="productObject">The product object.</param>
        /// <returns></returns>
        public ProductDetails addProductDetails(ProductDetails productObject)
        {
            try
            {
                var result = _productDetailsRepository.AddProductDetails(productObject);
                return result;
            }
            catch (Exception eX)
            {
                return new ProductDetails();
            }
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public List<ProductDetails> GetAllProducts()
        {
            try
            {
                var result = _productDetailsRepository.GetAllProducts();
                return result;
            }
            catch (Exception)
            {
                return new List<ProductDetails>();
            }
        }

        public List<ProductDetails> GetSelectedProducts(string category, string subcategory)
        {
            try
            {
                var result = _productDetailsRepository.GetSelectedProducts(category,  subcategory);
                return result;
            }
            catch (Exception)
            {
                return new List<ProductDetails>();
            }
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool DeleteProduct(long id)
        {
            try
            {
                var result = _productDetailsRepository.DeleteProduct(id);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ProductDetails GetProductById(long id)
        {
            try
            {
                var result = _productDetailsRepository.GetProductById(id);
                return result;
            }
            catch (Exception)
            {
                return new ProductDetails();
            }
        }
    }
}
