using APIProjectMCC75.Base;
using APIProjectMCC75.Models;
using APIProjectMCC75.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectMCC75.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLineController : BaseController<int, ProductLine, ProductLineRepository>
    {
        public ProductLineController(ProductLineRepository repository) : base(repository)
        {
        }
    }
}
