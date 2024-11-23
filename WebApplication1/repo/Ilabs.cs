using WebApplication1.Models;

namespace WebApplication1.repo
{
    public interface Ilabs
    {
        public List<labs> all();
        public labs Get(int id);
        public void save();
        public void delete(int id);

        public void update(labs labs);
        public void add(labs labs);
    }
}
