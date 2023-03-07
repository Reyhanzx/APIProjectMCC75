﻿using APIProjectMCC75.Base;
using APIProjectMCC75.Models;
using APIProjectMCC75.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectMCC75.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<int, Product, ProductRepository>
    {
        public ProductController(ProductRepository repository) : base(repository)
        {
        }
    }
}
