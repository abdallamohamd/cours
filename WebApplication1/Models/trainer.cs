using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int age { get; set; }

        [ForeignKey("courses")]
        public int courseid {  get; set; }
        public Courses? courses { get; set; }
    }
}
