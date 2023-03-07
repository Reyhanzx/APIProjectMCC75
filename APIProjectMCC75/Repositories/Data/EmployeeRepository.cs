using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;

namespace APIProjectMCC75.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<int, Employee>
    {
        private readonly MyContext context;

        public EmployeeRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
