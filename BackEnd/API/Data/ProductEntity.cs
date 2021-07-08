using System;
using System.ComponentModel.DataAnnotations;
namespace API.Data
{
    public class ProductEntity
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get;set; }
        
        [Key]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}