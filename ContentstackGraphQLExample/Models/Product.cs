namespace ContentstackGraphQLExample.Models
{
    public class Product
    {
        public System system { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public AssetConnection featured_imageConnection { get; set; }
    }
}
