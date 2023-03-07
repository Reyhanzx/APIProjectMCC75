using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<int, AccountRole>
    {
        private readonly MyContext context;

        public AccountRoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
