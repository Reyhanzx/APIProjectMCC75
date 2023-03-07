using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class OrderRepository : GeneralRepository<int, Order>
    {
        private readonly MyContext context;

        public OrderRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
