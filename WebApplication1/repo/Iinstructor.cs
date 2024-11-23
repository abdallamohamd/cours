using WebApplication1.Models;

namespace WebApplication1.repo
{
    public interface Iinstructor
    {
        public List<instructor> all();
        public instructor Get(int id);
        public void save();
        public void delete(int id);

        public void update(instructor instructor);
        public void add(instructor instructor);
    }
}
