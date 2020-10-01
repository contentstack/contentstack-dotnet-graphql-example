using System.Collections.Generic;

namespace ContentstackGraphQLExample.Models
{
    public class ProductCollection
    {
        public int total { get; set; }
        public List<Product> items { get; set; }
    }
}