using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.repo;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {  
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(Option => {

                Option.IdleTimeout = TimeSpan.FromSeconds(1);

             });

            builder.Services.AddDbContext<appcomtext>(option=>{
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddIdentity<appuser, IdentityRole>().AddEntityFrameworkStores<appcomtext>();

            builder.Services.AddScoped<Icourserepo, Courserepo>();
            builder.Services.AddScoped<Icategory, Categoryrepo>();
            builder.Services.AddScoped<Ilabs,labsrepo>();
            builder.Services.AddScoped<Itrainer,trainerrepo>();
            builder.Services.AddScoped<Iinstructor,instructorrepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
