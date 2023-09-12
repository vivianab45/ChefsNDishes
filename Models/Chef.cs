#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required(ErrorMessage ="First Name Required")]       
    [Display(Name="First Name:")] 
    public string FirstName { get; set; }
    
    [Required(ErrorMessage ="Last Name Required")]     
    [Display(Name="Last Name:")]   
    public string LastName { get; set; } 

    [Required]
    [DataType(DataType.Date)]
    [Display(Name="Date of Birth:")]  
    [PastDate]
    public DateTime DoB {get;set;}
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //it's recommended to do an empty list instead of null
    public List<Dish> AllDishes { get; set; } = new List<Dish>();

    public int Age
    {
        get{ return DateTime.Now.Year-DoB.Year;}
    }

}

//validation: DOB must be in the past
public class PastDateAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid (object value, ValidationContext validationContext)
    {
        if (((DateTime)value) > DateTime.Now)
        {
            return new ValidationResult ("Date must be in the past");
        } else{
            return ValidationResult.Success;
        }
    }
}


