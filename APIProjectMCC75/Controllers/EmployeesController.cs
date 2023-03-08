using APIProjectMCC75.Base;
using APIProjectMCC75.Models;
using APIProjectMCC75.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectMCC75.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : BaseController<string, Employee, EmployeeRepository>
    {
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
        }
    }
}
