using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class ProducersController : Controller
{
    // GET_
    private readonly IProducersService _service ;

    public ProducersController(IProducersService service)
    {
        _service = service;
    }
   
    public async Task<ActionResult> Index()
    {
        var producers = await _service.GetAllAsync();
        return View(producers);
    }

    public async Task<ActionResult> Details(int id)
    {
        var producerDerails = await _service.GetByIdAsync(id);
        return producerDerails is null ? View("NotFound") : View(producerDerails);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind()]Producer producer)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("model is not valid");
            foreach (var modelStateValue in ModelState.Keys)
            {
                Console.WriteLine(modelStateValue);
            }
            
            return View();
        }
        await _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }
    public  ActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")]Producer producer)
    {
        if (!ModelState.IsValid)
        {
           return View();
        }
        await _service.UpdateAsync(id,producer);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var producerDerails = await _service.GetByIdAsync(id);
        return producerDerails is null ? View("NotFound") : View(producerDerails);
    }
    
    [HttpPost,ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (!ModelState.IsValid)
        {
           return View();
        }
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null)
        {
            return View("NotFound");
        }
        return View(producerDetails);
    }
}