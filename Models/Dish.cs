#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage="Must inlude Dish Name")]
    public string Name { get; set; } 

    [Required]
    [Range(1,5)]
    public int Tastiness { get; set; }

    [Required (ErrorMessage="Calories must be included.")]
    [Range(0,int.MaxValue, ErrorMessage ="Calories must be at least 0")]
    public int Calories { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    ///the ID we will use to know which Chef made the dish
    [Required(ErrorMessage="Must select a Chef")]
    [Display(Name = "Chef")]
    public int ChefId { get; set; }

    //navigation property to track which chef made this dish
    public Chef? Creator { get; set; }
}