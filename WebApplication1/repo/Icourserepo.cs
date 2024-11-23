using WebApplication1.Models;

namespace WebApplication1.repo
{
    public interface Icourserepo
    {
        public List<Courses> all();
        public Courses Get(int id);
        public void save();
        public void delete(int id);

        public void update(Courses course);
        public void add(Courses course);
    }
}
