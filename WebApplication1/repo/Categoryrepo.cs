using WebApplication1.Models;

namespace WebApplication1.repo
{
    public class Categoryrepo : Icategory
    {
        private readonly appcomtext context;

        public Categoryrepo(appcomtext context)
        {
            this.context = context;
        }

        public void add(category category)
        {
             context.categories.Add(category);    
        }

        public List<category> all()
        {
            return context.categories.ToList();
        }

        public void delete(int id)
        {
            category category= Get(id);
            context.categories.Remove(category);
        }

        public category Get(int id)
        {
           return context.categories.FirstOrDefault(x=>x.Id==id);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void update(category category)
        {
            context.categories.Update(category);
        }
    }
}
