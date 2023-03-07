using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class PaymentRepository : GeneralRepository<string, Payment>
    {
        private readonly MyContext context;

        public PaymentRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
