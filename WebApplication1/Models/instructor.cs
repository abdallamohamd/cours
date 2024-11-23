namespace WebApplication1.Models
{
    public class instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal sale { get; set; }
        public string phone { get; set; }
        public ICollection<Courses>? courses { get; set; }
    }
}
