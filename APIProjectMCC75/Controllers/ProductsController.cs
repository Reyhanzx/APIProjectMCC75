using APIProjectMCC75.Base;
using APIProjectMCC75.Models;
using APIProjectMCC75.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectMCC75.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<int, Product, ProductRepository>
    {
        public ProductsController(ProductRepository repository) : base(repository)
        {
        }
    }
}
