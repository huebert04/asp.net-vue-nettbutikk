using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using API.Data;
using API.Common;

namespace API
{
    public class ProductService
    {
        private readonly ProductDbContext _db;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ProductService(ProductDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _db = dbContext;
            _dateTimeProvider = dateTimeProvider;

        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return _db.ProductSet.Select(x => x.ToDomain()).ToList();
        }

        public async Task<Product?> GetByID(string id)
        {
            var product = _db.ProductSet.FirstOrDefault(p => p.ProductID == id);
            var domainModel = product?.ToDomain();
            return domainModel;
        }

        public async Task<Product?> CreateNewProduct(Product p)
        {
            var productExists = await GetByID(p.ProductID) != null;

            if(productExists)
            {
                return null;
            }
            var newProduct = p.ToEntity();
            newProduct.CreatedDateTime = _dateTimeProvider.Now();
            newProduct.ModifiedDateTime = _dateTimeProvider.Now();

            _db.ProductSet.Add(newProduct);
            await _db.SaveChangesAsync();
            return p;
        }

        public async Task<Product?> UpdateProduct(Product p)
        {
            var productExists = await GetByID(p.ProductID) != null;

            if(!productExists)
            {
                return null;
            }

            var product = _db.ProductSet.FirstOrDefault(obj => obj.ProductID == p.ProductID);

            product.ProductName = p.ProductName;
            product.Price = p.Price;
            product.Category = p.Category;
            product.Description = p.Description;
            product.Image = p.Image;
            product.ModifiedDateTime = _dateTimeProvider.Now();

            _db.ProductSet.Update(product);
            await _db.SaveChangesAsync();

            return p;
        }

        public async Task<Product?> DeleteByID(string id)
        {
            var personExists = await GetByID(id) != null;
            
            if(!personExists)
            {
                return null;
            }

            var product = _db.ProductSet.FirstOrDefault(obj => obj.ProductID == id);
            _db.ProductSet.Remove(product);
            await _db.SaveChangesAsync();

            var domainModel = product.ToDomain();
            return domainModel;
        }

    }
}