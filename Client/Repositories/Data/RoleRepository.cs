﻿using Client.Models;

namespace Client.Repositories.Data
{
    public class RoleRepository : GeneralRepository<int, Role>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public RoleRepository(string request = "Role/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7203/api/")
            };
        }
    }
}
