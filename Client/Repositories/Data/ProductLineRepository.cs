using Client.Models;

namespace Client.Repositories.Data;

public class ProductLineRepository : GeneralRepository<int, ProductLine>
{
    //private readonly string request;
    //private readonly HttpClient _httpClient;
    public ProductLineRepository(string request = "ProductLines/") : base(request)
    {
        //this.request = request;
        //_httpClient = new HttpClient()
        //{
        //    BaseAddress = new Uri("https://localhost:7203/api/")
        //};
    }
}
