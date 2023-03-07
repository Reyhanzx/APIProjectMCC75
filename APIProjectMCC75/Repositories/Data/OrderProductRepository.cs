using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class OrderProductRepository : GeneralRepository<int, OrderProduct>
    {
        private readonly MyContext context;

        public OrderProductRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
