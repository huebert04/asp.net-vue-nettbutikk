namespace API.Contracts
{
    public class ProductCreateModel
    {
        public string? ProductID {get; set;}
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }

}