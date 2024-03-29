﻿using Client.Models;

namespace Client.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<int, AccountRole>
    {
        private readonly string request;
    private readonly HttpClient _httpClient;
        public AccountRoleRepository(string request = "AccountRole/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7203/api/")
            };
        }
    }
}
