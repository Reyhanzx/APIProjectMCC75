using Client.Models;

namespace Client.Repositories.Data
{
    public class PaymentRepository : GeneralRepository<int, Payment>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public PaymentRepository(string request = "Payment/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7022/api/")
            };
        }
    }
}
