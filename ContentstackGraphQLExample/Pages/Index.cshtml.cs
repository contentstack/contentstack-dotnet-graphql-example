using System;
using System.Threading.Tasks;
using ContentstackGraphQLExample.Models;
using GraphQL;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContentstackGraphQLExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GraphQLHttpClient _client;

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public int TotalPages => (int) Math.Ceiling(decimal.Divide(Products?.total ?? 0, PageSize));

        public ProductCollection Products { get; set; }

        public IndexModel(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task OnGetAsync()
        {
            var query = new GraphQLRequest
            {
                Query = @"query Products($skip: Int, $limit: Int){
                  all_product(locale: ""en-us"", skip: $skip, limit: $limit) {
                    total
                    items {
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
                  }
                }",

                OperationName = "Products",

                Variables = new {
                    skip = (CurrentPage - 1) * PageSize,
                    limit = PageSize
                }
            };

            var response = await _client.SendQueryAsync<AllProductResponse>(query);
            Products = response.Data.all_product;
        }
    }
}
