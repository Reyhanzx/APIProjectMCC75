using Client.Models;

namespace Client.Repositories.Data;

public class OrderProductRepository : GeneralRepository<int, OrderProduct>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public OrderProductRepository(string request = "OrderProduct/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7203/api/")
        };
    }
}
