using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class CustomerRepository : GeneralRepository<int, Customer>
    {
        private readonly MyContext context;

        public CustomerRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
