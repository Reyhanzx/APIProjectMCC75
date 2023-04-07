using Client.Models;

namespace Client.Repositories.Data
{
    public class OrderRepository : GeneralRepository<int, Order>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public OrderRepository(string request = "Order/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7203/api/")
            };
        }
    }
}
