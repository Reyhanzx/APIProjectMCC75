using Client.Models;

namespace Client.Repositories.Data
{
    public class ProductRepository : GeneralRepository<int, Product>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public ProductRepository(string request = "Product/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7203/api/")
            };
        }
    }
}
