using API.Data;
using API.Contracts;

namespace API.Common
{
    public static class ProductExtension
    {
        public static ProductEntity ToEntity(this Product domain)
        {
            return new ProductEntity
            {
                ProductID = domain.ProductID,
                ProductName = domain.ProductName,
                Price = domain.Price,
                Category = domain.Category,
                Description = domain.Description,
                Image = domain.Image
            };
        }

        public static ProductViewModel ToViewModel(this Product domain)
        {
            return new ProductViewModel(domain.ProductID, domain.ProductName, domain.Price, domain.Category, domain.Description, domain.Image);
        }

    }
}