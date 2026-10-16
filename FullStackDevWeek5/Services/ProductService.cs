using FullStackDevWeek5.Models;
using System.Text.Json;

namespace FullStackDevWeek5.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Models.Product>> GetProductsAsync()
        {


            return await _httpClient.GetFromJsonAsync<List<Product>>("https://edutots.net/api/product") ?? new List<Models.Product>();

        }



        public async Task<Models.Product> GetProductByIdAsync(int id)
        {

            var response = await _httpClient.GetAsync($"https://edutots.net/api/product/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<Models.Product>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return product;


        }

        public async Task<Models.Product> AddProductAsync(Models.Product product)
        {


            var response = await _httpClient.PostAsJsonAsync("https://edutots.net/api/product/", product);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonSerializer.Deserialize<Models.Product>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return createdProduct ?? product;

        }



        public async Task<bool> UpdateProductAsync(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync(
            $"https://edutots.net/api/product/{product.Id}",
            product);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)

        {

            var response = await _httpClient.DeleteAsync($"https://edutots.net/api/product/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;

        }

    }
}
