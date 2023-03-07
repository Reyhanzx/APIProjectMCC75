using APIProjectMCC75.Handlers;
using APIProjectMCC75.Contexts;
using APIProjectMCC75.Models;
using APIProjectMCC75.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace APIProjectMCC75.Repositories.Data
{
    public class AccountRepository : GeneralRepository<int, Account>
    {
        private readonly MyContext context;

        public AccountRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<int> Register(RegisterVM registerVM)
        {
            int result = 0;
            Employee employee = new Employee
            {
                OfficeCode = registerVM.OfficeCode,
                ReportsTo= registerVM.ReportsTo,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,               
                Email = registerVM.Email,
                JobTitle = registerVM.JobTitle,
            };
            await context.Employees.AddAsync(employee);
            result = await context.SaveChangesAsync();

            Account account = new Account
            {
                Id = registerVM.OfficeCode,
                Password = Hashing.HashPassword(registerVM.Password)
            };
            await context.Accounts.AddAsync(account);
            result = await context.SaveChangesAsync();

            AccountRole accountRole = new AccountRole
            {
                AccountId = registerVM.OfficeCode,
                RoleId = 2
            };

            await context.AccountRoles.AddAsync(accountRole);
            result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var result = await context.Employees
                .Include(e => e.Account)
                .Select(e => new LoginVM
                {
                    Email = e.Email,
                    Password = e.Account.Password
                }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

            if (result is null)
            {
                return false;
            }
            return Hashing.ValidatePassword(loginVM.Password, result.Password);
        }

        public async Task<UserdataVM> GetUserdata(string key)
        {
            var userdata = (from e in context.Employees
                            join a in context.Accounts
                            on e.Id equals a.Id
                            join ar in context.AccountRoles
                            on a.Id equals ar.AccountId
                            join r in context.Roles
                            on ar.RoleId equals r.Id
                            where e.Email == key
                            select new UserdataVM
                            {
                                Email = e.Email,
                                FullName = String.Concat(e.FirstName, " ", e.LastName),

                            }).SingleOrDefaultAsync();

            return await userdata;
        }

        public async Task<IEnumerable<string>> GetRolesById(string key)
        {
            var getNik = context.Employees.FirstOrDefault(e => e.Email == key);
            return await context.AccountRoles.Where(ar => ar.AccountId == getNik.Id).Join(
                context.Roles,
                ar => ar.RoleId,
                r => r.Id,
                (ar, r) => r.Name).ToListAsync();
        }
    }
}
