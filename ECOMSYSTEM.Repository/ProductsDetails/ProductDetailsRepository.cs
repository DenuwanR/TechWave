using AutoMapper;
using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.ProductsDetails
{
    public class ProductDetailsrepository : IProductDetailsRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ECOM_WebContext _dbContext = new ECOM_WebContext();
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserRepository"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public ProductDetailsrepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Adds the product details.
        /// </summary>
        /// <param name="productObject">The user object.</param>
        /// <returns></returns>
        public ProductDetails AddProductDetails(ProductDetails productObject)
        {
            try
            {
                if (productObject.ProductId > 0)
                {
                    var result = _dbContext.TblProducts.Where(u => u.ProductId == productObject.ProductId).FirstOrDefault();
                    if (result == null) { return new ProductDetails(); }
                    result.ProductName = productObject.ProductName;
                    result.Price = productObject.Price;
                    result.Description = productObject.Description;
                    result.CreatedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    var mappedobject = _mapper.Map<ProductDetails>(result);
                    if (mappedobject != null) return mappedobject;
                    return new ProductDetails();
                }
                else
                {
                    var MappedObject = _mapper.Map<TblProduct>(productObject);

                    _dbContext.TblProducts.Add(MappedObject);
                    var result = _dbContext.SaveChanges();

                    productObject.ProductId = MappedObject.ProductId;
                    if (result > 0) return productObject;

                    return new ProductDetails();
                }

                return new ProductDetails();
            }
            catch (Exception eX)
            {
                return new ProductDetails(); ;
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
                var products = _dbContext.TblProducts.ToList();
                var mappedUsers = _mapper.Map<List<ProductDetails>>(products);
                return mappedUsers;
            }
            catch (Exception eX)
            {
                return new List<ProductDetails>();
            }
        }
        public List<ProductDetails> GetSelectedProducts(string category, string subcategory)
        {
            try
            {
                int productCategoryId = int.Parse(category);
                int productSubCategoryId = int.Parse(subcategory);

                var products = _dbContext.TblProducts.Where(x => x.ProductCategoryId == productCategoryId && x.ProductSubCategoryId == productSubCategoryId).ToList();
                var mappedUsers = _mapper.Map<List<ProductDetails>>(products);
                return mappedUsers;
            }
            catch (Exception eX)
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
                var item = _dbContext.TblProducts.Where(x => x.ProductId == id).FirstOrDefault();
                _dbContext.TblProducts.Remove(item);
                var result = _dbContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
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
                var result = new TblProduct();
                if (id == 0)
                {
                    return new ProductDetails();
                }

                result = _dbContext.TblProducts.Select(data => data).
                Where(data => data.ProductId == id).FirstOrDefault();

                var mappedobject = _mapper.Map<ProductDetails>(result);
                if (mappedobject != null) return mappedobject;
                return new ProductDetails();
            }
            catch (Exception)
            {
                return new ProductDetails();
            }
        }
    }
}
