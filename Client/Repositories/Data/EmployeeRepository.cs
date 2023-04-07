using Client.Models;

namespace Client.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<string, Employee>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public EmployeeRepository(string request = "Employee/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7203/api/")
            };
        }
    }
}
