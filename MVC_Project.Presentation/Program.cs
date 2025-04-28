using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC_Project.BusinessLayer.Profiles;
using MVC_Project.BusinessLayer.Services.Classes;
using MVC_Project.BusinessLayer.Services.Interfaces;
using MVC_Project.DataAccess.Data.Contexts;
using MVC_Project.DataAccess.Repositories.Classes;
using MVC_Project.DataAccess.Repositories.Interfaces;
namespace MVC_Project.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            #region Add Service to Container

            builder.Services.AddControllersWithViews(Options =>
            {
                Options.Filters.Add( new AutoValidateAntiforgeryTokenAttribute() ); 
            });
            //builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddAutoMapper (M=> M.AddProfile(new MappingProfiles()));
            

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
