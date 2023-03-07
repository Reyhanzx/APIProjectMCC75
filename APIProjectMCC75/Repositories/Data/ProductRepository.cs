using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class ProductRepository : GeneralRepository<int, Product>
    {
        private readonly MyContext context;

        public ProductRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
