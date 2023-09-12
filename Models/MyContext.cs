#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ChefsNDishes.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) {}

    //tables
    public DbSet<Dish> Dishes {get;set;}
    public DbSet<Chef> Chefs {get;set;}
}