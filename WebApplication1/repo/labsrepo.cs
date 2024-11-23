using WebApplication1.Models;

namespace WebApplication1.repo
{
    public class labsrepo : Ilabs
    {
        private readonly appcomtext context;

        public labsrepo(appcomtext context)
        {
            this.context = context;
        }

        public void add(labs labs)
        {
            context.labs.Add(labs);
        }

        public List<labs> all()
        {
            return context.labs.ToList();
        }

        public void delete(int id)
        {
            labs labs = Get(id);
            context.labs.Remove(labs);
        }

        public labs Get(int id)
        {
            return context.labs.FirstOrDefault(x => x.Id == id);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void update(labs labs)
        {
            context.Update(labs);
        }
    }
}
