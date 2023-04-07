using Client.Models;

namespace Client.Repositories.Data;

public class CustomerRepository : GeneralRepository<int, Customer>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public CustomerRepository(string request = "Customer/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7203/api/")
        };
    }
}
