using System;
using API.Contracts;

namespace API.Common
{
    public static class ProductUpdateModelExtension
    {
        public static Product ToDomain(this ProductUpdateModel updateModel)
        {
            if(updateModel.ProductName is null) throw new ArgumentNullException(nameof(updateModel.ProductName));
            if(updateModel.Price is null) throw new ArgumentException(nameof(updateModel.Price));
            if(updateModel.Category is null) throw new ArgumentException(nameof(updateModel.Category));
            if(updateModel.Description is null) throw new ArgumentException(nameof(updateModel.Description));
            if(updateModel.Image is null) throw new ArgumentException(nameof(updateModel.Image));
            return new Product(updateModel.ProductID, updateModel.ProductName, updateModel.Price.Value, updateModel.Category, updateModel.Description, updateModel.Image);
        }
    }
}