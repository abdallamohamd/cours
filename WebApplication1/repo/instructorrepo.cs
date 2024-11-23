using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.repo
{
    public class instructorrepo : Iinstructor
    {
        private readonly appcomtext context;

        public instructorrepo(appcomtext context)
        {
            this.context = context;
        }

        public void add(instructor instructor)
        {
            context.instructors.Add(instructor);
        }

        public List<instructor> all()
        {
         return   context.instructors.ToList();   
        }

        public void delete(int id)
        {
            instructor instructor = Get(id);
            context.instructors.Remove(instructor);
        }

        public instructor Get(int id)
        {
            return context.instructors.FirstOrDefault(x => x.Id == id);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void update(instructor instructor)
        {
            context.Update(instructor);
        }
    }
}
