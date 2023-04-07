using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;



namespace Client.Controllers;

public class OfficeController : BaseController<int, Office, OfficeRepository>
{
    private readonly OfficeRepository repository;

    public OfficeController(OfficeRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var office = new List<Office>();

        if (result.Data != null)
        {
            office = result.Data.ToList();
        }

        return View(office);
    }
    public IActionResult Create()
    {
        return View();
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public IActionResult Create()
    //{

    //    return View();
    //}
}
