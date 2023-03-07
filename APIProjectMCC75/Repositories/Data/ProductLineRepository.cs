using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class ProductLineRepository : GeneralRepository<int, ProductLine>
    {
        private readonly MyContext context;

        public ProductLineRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
