using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApplication1.Models;

namespace WebApplication1.repo
{
    public class Courserepo : Icourserepo
    {
        private readonly appcomtext context;

        public Courserepo(appcomtext context)
        {
            this.context = context;
        }

        public void add(Courses course)
        {
            context.courses.Add(course);
        }

        public List<Courses> all()
        {
            return context.courses.Include(c=>c.category).OrderBy(i=>i.categoryid).ToList();  
        }

        public void delete(int id)
        {
                  Courses course = Get(id);
            context.courses.Remove(course);
        }

        public Courses Get(int id)
        {
            return context.courses.FirstOrDefault(x => x.Id == id);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void update(Courses course)
        {
           context.courses.Update(course);   
        }
    }
}
