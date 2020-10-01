using System.Threading.Tasks;
using ContentstackGraphQLExample.Models;
using GraphQL;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContentstackGraphQLExample.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly GraphQLHttpClient _client;

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Uid { get; set; }

        public DetailsModel(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task OnGetAsync()
        {
            var query = new GraphQLRequest
            {
                Query = @"query Product($productid: String!) {
                    product(uid: $productid) {
                      system {
                         uid
                      }
                      title
                      description
                      price
                      featured_imageConnection (limit: 10) {
                         edges {
                            node {
                                url
                                filename
                            }
                        }
                      }  
                    }
                }",

                OperationName = "Product",
                Variables = new
                {
                    productid = Uid
                }
            };

            var response = await _client.SendQueryAsync<ProductResponse>(query);
            Product = response.Data.product;
        }
    }
}
