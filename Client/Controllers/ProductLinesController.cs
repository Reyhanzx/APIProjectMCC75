using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class ProductLinesController : BaseController<int, ProductLine, ProductLineRepository>
{
    private readonly ProductLineRepository repository;

    public ProductLinesController(ProductLineRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var productline = new List<ProductLine>();

        if (result.Data != null)
        {
            productline = result.Data.ToList();
        }
        return View(productline);
    }
     
    [HttpGet]
    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await repository.Get(id);
        var productline = new ProductLine();

        if (result.Data != null)
        {
            productline.Id = result.Data.Id;
            productline.Name = result.Data.Name;
        }
        return View(productline);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //ini buat Create Post nya
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductLine productLine)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(productLine);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await repository.Get(id);
        var productline = new ProductLine();

        if (result.Data != null)
        {
            productline.Id = result.Data.Id;
            productline.Name = result.Data.Name;
        }
        return View(productline);
    }

   
    public async Task<IActionResult> Edit(ProductLine productLine, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(productLine, id);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await repository.Get(id);
        //var productline = new ProductLine();

        //if (result.Data != null)
        //{
        //    productline.Id = result.Data.Id;
        //    productline.Name = result.Data.Name;
        //}
        //return View(productline);
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Delete(id);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return RedirectToAction(nameof(Index));
    }
}
