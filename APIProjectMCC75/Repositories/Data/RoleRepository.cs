using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class RoleRepository : GeneralRepository<int, Role>
    {
        private readonly MyContext context;

        public RoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
