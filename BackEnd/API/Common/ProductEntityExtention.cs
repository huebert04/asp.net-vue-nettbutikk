using System;
using API.Data;

namespace API.Common
{
    public static class ProductEntityExtention
    {
        public static Product ToDomain(this ProductEntity entity)
        {
            return new Product(entity.ProductID, entity.ProductName, entity.Price, entity.Category, entity.Description, entity.Image);
        }
    }
}