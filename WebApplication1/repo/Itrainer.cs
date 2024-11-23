using WebApplication1.Models;

namespace WebApplication1.repo
{
    public interface Itrainer
    {
        public List<trainer> all();
        public trainer Get(int id);
        public void save();
        public void delete(int id);

        public void update(trainer trainer);
        public void add(trainer trainer);
    }
}
