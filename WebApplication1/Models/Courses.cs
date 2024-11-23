using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.validation;

namespace WebApplication1.Models
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        [uniqname]
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        [Required]
        
        public DateTime startDate { get; set; }
        [Required]
     
        [ForeignKey("category")]
        
        public int categoryid { get; set; }
        
        [ForeignKey("labs")]
        public int labid {  get; set; }

        [ForeignKey("instructor")]
        public int insid {  get; set; }
         
        public ICollection<trainer>? trainers { get; set; }
        public instructor? instructor { get; set; }
        public labs? labs { get; set; }
        public category? category { get; set; }

    }
}
