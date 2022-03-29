using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class CinemasController : Controller
{
    // GET
    private readonly ICinemasService _service;

    public CinemasController(ICinemasService service)
    {
        _service = service;
    }
   
    public async Task<ActionResult> Index()
       {
          var cinemas = await _service.GetAllAsync(); 
          return View(cinemas);
       }
       [HttpPost]
       public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
       {
          if (!ModelState.IsValid)
          {
             return View(cinema);
          }
          await _service.AddAsync(cinema);
          return RedirectToAction(nameof(Index));
       }
       public  ActionResult Create()
       {
          return View();
       }
    
       public async Task<IActionResult> Details(int id)
       {
          
          var actorDetails = await _service.GetByIdAsync(id);
          if (actorDetails == null)
          {
             return View("NotFound");
          }
    
          return View(actorDetails);
       }
       
       [HttpPost]
       public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")]Cinema cinema)
       {
          // if (!ModelState.IsValid)
          // {
          //    return View();
          // }
          await _service.UpdateAsync(id,cinema);
          return RedirectToAction(nameof(Index));
       }
       public async  Task<ActionResult> Edit(int id)
       {
          var cinemaDetails = await _service.GetByIdAsync(id);
          return cinemaDetails == null ? View("NotFound") : View(cinemaDetails);
       }
       
       [HttpPost,ActionName("Delete")]
       public async Task<IActionResult> DeleteConfirm(int id)
       {
          
          await _service.DeleteAsync(id);
          return RedirectToAction(nameof(Index));
       }
       
       
       public async  Task<ActionResult> Delete(int id)
       {
          var actorDetails = await _service.GetByIdAsync(id);
          if (actorDetails == null)
          {
             return View("NotFound");
          }
          return View(actorDetails);
       }
}