using WebApplication1.Models;

namespace WebApplication1.repo
{
    public interface Icategory

    { 
    public List<category> all();
    public category Get(int id);
    public void save();
    public void delete(int id);

    public void update(category category);
    public void add(category category);
}
}
