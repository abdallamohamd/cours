using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.validation;

namespace WebApplication1.Models
{
    public class category
    {
        public int Id { get; set; }
        [Required]
        [uniqname]
        public string Name { get; set; }
        public ICollection<Courses>? courses { get; set; }
    }
}
