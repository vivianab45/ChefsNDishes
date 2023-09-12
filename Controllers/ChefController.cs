using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;
    //add context
    private MyContext _context;  

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context= context;        
    }
   //////Add New Chef
    //-----get form-----
    [HttpGet("")]
    public IActionResult NewChef()
    {
        return View();
    }
    //---process form---
    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(!ModelState.IsValid)
        {
            return View ("NewChef");
        } else{

        _context.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction ("AllChefs");
        }

    }



    //////GET ALL
    [HttpGet("chefs/all")]
    public ViewResult AllChefs()
    {
        // List<Chef> AllChefs= _context.Chefs.OrderByDescending(d=>d.CreatedAt).ToList();
        List<Chef> EveryChef= _context.Chefs.Include(c=>c.AllDishes).ToList();
        ViewBag.AllChefs= EveryChef;
    
        return View ("AllChefs");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
