using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    //add context
    private MyContext _context;    

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context= context;
    }
    // //////GET ALL

    [HttpGet("dishes/all")]
    public ViewResult AllDishes()
    {
        List<Dish> Dishes= _context.Dishes.Include(d=>d.Creator).ToList();

        return View ("AllDishes", Dishes);
    }

    //////Add New
    //-----get form-----
    [HttpGet("dishes/new")]
    public ViewResult NewDish()
    {
            List<Chef> EveryChef = _context.Chefs.ToList();
            ViewBag.AllChefs = EveryChef;

        return View("NewDish");
    }
    //---process form---
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(!ModelState.IsValid)
        {
            List<Chef> EveryChef = _context.Chefs.ToList();
            ViewBag.AllChefs = EveryChef;
            return View("NewDish");
        }
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction ("AllDishes");
    }

}