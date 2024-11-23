using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.validation;

namespace WebApplication1.Models
{
    public class labs
    {
        public int Id { get; set; }
        [Required]
        [uniqname]
        public string name { get; set; }
        public ICollection<Courses>? courses { get; set; }

    }
}
