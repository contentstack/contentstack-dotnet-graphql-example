using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContentstackGraphQLExample
{
    public class ContentstackOptions
    {
        public string Host { get; set; }
        public string ApiKey { get; set; }
        public string DeliveryToken { get; set; }
        public string Environment { get; set; }

        public string Endpoint
        {
            get
            {
                var protocol = Host?.StartsWith("https://") ?? false ? string.Empty : "https://";
                return $"{protocol}{Host}/stacks/{ApiKey}?environment={Environment}";
            }
        }
    }
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var options = new ContentstackOptions();
            Configuration.GetSection("ContentstackOptions").Bind(options);

            var httpClient = new GraphQLHttpClient(options.Endpoint, new NewtonsoftJsonSerializer());
            httpClient.HttpClient.DefaultRequestHeaders.Add("access_token", options.DeliveryToken);

            services.AddSingleton(s => httpClient);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
