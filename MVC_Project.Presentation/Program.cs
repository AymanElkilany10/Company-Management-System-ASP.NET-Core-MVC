using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC_Project.DataAccess.Data.Contexts;
using MVC_Project.DataAccess.Repositories;
namespace MVC_Project.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Add Service to Container
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>(); 

            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion


            app.Run();
        }
    }
}
