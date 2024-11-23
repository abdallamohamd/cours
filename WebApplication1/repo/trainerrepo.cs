using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.repo
{
    public class trainerrepo : Itrainer
    {
        private readonly appcomtext context;

        public trainerrepo(appcomtext context)
        {
            this.context = context;
        }

        public void add(trainer trainer)
        {
            context.trainers.Add(trainer);
        }

        public List<trainer> all()
        {
           return context.trainers.Include(x=>x.courses).ToList();
        }

        public void delete(int id)
        {
            trainer trainer = Get(id);
        }

        public trainer Get(int id)
        {
            return context.trainers.FirstOrDefault(x => x.Id == id);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void update(trainer trainer)
        {
            context.Update(trainer);
        }
    }
}
