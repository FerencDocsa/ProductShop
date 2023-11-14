using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.DataContexts;

namespace ProductShop.IntegrationTests
{
    public static class Utilities
    {
        public static void SeedData(ShopDbContext context)
        {
            context.Products.AddRange(GetSeedData());
            context.SaveChanges();
        }

        public static void ReSeedData(ShopDbContext context)
        {
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();
            SeedData(context);
        }

        public static List<Product> GetSeedData()
        {
            return new List<Product>()
            {
                new(1, "Test1", new Uri("http://test/com"), 100, "test1"),
                new(2, "Test2", new Uri("http://test/com"), 100, "test2"),
                new(3, "Test3", new Uri("http://test/com"), 100, "test3"),
                new(4, "Test4", new Uri("http://test/com"), 100, "test4"),
                new(5, "Test5", new Uri("http://test/com"), 100, "test5"),
                new(6,"Test6", new Uri("http://test/com"), 100, "test6"),
                new(7,"Test7", new Uri("http://test/com"), 100, "test7"),
                new(8, "Test8", new Uri("http://test/com"), 100, "test8"),
                new(9, "Test9", new Uri("http://test/com"), 100, "test9"),
                new(10, "Test10", new Uri("http://test/com"), 100, "test10"),
            };
        }

        public static async Task<HttpResponseMessage> MakeApiCallAsync(HttpClient client, string apiRoute, HttpMethod httpMethod, object request = null)
        {
            var requestAsJson = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(requestAsJson, Encoding.UTF8, "application/json");

            if (httpMethod == HttpMethod.Post)
            {
                var response = await client.PostAsync(apiRoute, httpContent);
                return response;
            }

            if (httpMethod == HttpMethod.Get)
            {
                var response = await client.GetAsync(apiRoute);
                return response;
            }

            if (httpMethod == HttpMethod.Put)
            {
                var response = await client.PutAsync(apiRoute, httpContent);
                return response;
            }

            return new HttpResponseMessage();
        }
    }
}
