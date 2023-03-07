using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class OfficeRepository : GeneralRepository<int, Office>
    {
        private readonly MyContext context;

        public OfficeRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
