using System;
using API.Contracts;

namespace API.Common
{
    public static class ProductCreateModelExtension
    {
        public static Product ToDomain(this ProductCreateModel createModel)
        {
            if(createModel.ProductName is null) throw new ArgumentNullException(nameof(createModel.ProductName));
            if(createModel.Price is null) throw new ArgumentException(nameof(createModel.Price));
            if(createModel.Category is null) throw new ArgumentException(nameof(createModel.Category));
            if(createModel.Description is null) throw new ArgumentException(nameof(createModel.Description));
            if(createModel.Image is null) throw new ArgumentException(nameof(createModel.Image));
            return new Product(createModel.ProductID, createModel.ProductName, createModel.Price.Value, createModel.Category, createModel.Description, createModel.Image);
        }
    }
}