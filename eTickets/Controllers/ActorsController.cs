using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class ActorsController : Controller
{
   private readonly IActorsService _service;

   public ActorsController(IActorsService service)
   {
      _service = service;
   }
   
   public async Task<ActionResult> Index()
   {
      var actors = await _service.GetAllAsync(); 
      return View(actors);
   }
   [HttpPost]
   public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
   {
      if (!ModelState.IsValid)
      {
         return View();
      }
      await _service.AddAsync(actor);
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
   public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")]Actor actor)
   {
      // if (!ModelState.IsValid)
      // {
      //    return View();
      // }
      await _service.UpdateAsync(id,actor);
      return RedirectToAction(nameof(Index));
   }
   public async  Task<ActionResult> Edit(int id)
   {
      var actorDetails = await _service.GetByIdAsync(id);
      if (actorDetails == null)
      {
         return View("NotFound");
      }
      return View(actorDetails);
   }
   
   [HttpPost,ActionName("Delete")]
   public async Task<IActionResult> DeleteConfirm(int id)
   {
      // if (!ModelState.IsValid)
      // {
      //    return View();
      // }
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