using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.validation
{
    public class uniqnameAttribute : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            string name= value.ToString();

            
            if( name !=null )
            {
                return new ValidationResult("this name is used");
            }

            return ValidationResult.Success;


        }

    }
}
