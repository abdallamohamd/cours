using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;

namespace WebApplication1.Models
{
    public class appuser : IdentityUser
    {
        public string? address {  get; set; }  
        
        
    }
}
