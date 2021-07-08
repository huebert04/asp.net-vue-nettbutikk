namespace API.Contracts
{
    public class ProductViewModel
    {
        public ProductViewModel(string productid, string productname, double price, string category, string description, string image)
        {
            ProductID = productid;
            ProductName = productname;
            Price = price;
            Category = category;
            Description = description;
            Image = image;
        }

        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}