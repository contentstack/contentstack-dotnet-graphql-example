using System;
namespace contentstack_dotnet_graphql_example.Models
{
    public class AllProductResponse
    {
        public ProductCollection all_product { get; set; }
    }
    public class ProductResponse
    {
        public Product product { get; set; }
    }
}
