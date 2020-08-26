using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contentstack_dotnet_graphql_example.Models;
using GraphQL;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace contentstack_dotnet_graphql_example.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly String _contentType = "product";
        private readonly ILogger<DetailsModel> _logger;

        private readonly GraphQLHttpClient _client;

        [BindProperty]
        public ProductResponse Product { get; set; }

        public DetailsModel(ILogger<DetailsModel> logger, GraphQLHttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task OnGetAsync(string productuid)
        {
            var query = new GraphQLRequest
            {
                Query = @"query Product($productid: String){
                   all_product(locale:""en-us"", where: {
                        title: $productid
                    }) {
                    total
                    items{
                      title
                      description
                      price
                      featured_imageConnection (limit: 10){
                         edges{
                            node {
                                url
                                filename
                            }
                        }
                      }  
                    }
                  }
                }",
                OperationName = "Product",
                Variables = new
                {
                    productid = productuid
                }
            };
            try
            {
                var response = await _client.SendQueryAsync<ProductResponse>(query);
                Console.WriteLine(response.Data);
                Product = response.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
