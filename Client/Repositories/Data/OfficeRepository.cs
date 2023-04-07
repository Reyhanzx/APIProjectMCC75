using Client.Models;

namespace Client.Repositories.Data;

public class OfficeRepository : GeneralRepository<int, Office>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public OfficeRepository(string request = "Offices/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7203/api/")
        };
    }
}
