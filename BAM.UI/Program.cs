using BAM.Business.Abstract;
using BAM.Business.Concrete;
using BAM.DataAccess.Abstract;
using BAM.DataAccess.Concrete.EntityFramework;
using BAM.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BAM.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddSingleton<IBookDal, EfBookDal>();
            builder.Services.AddSingleton<IBookService, BookManager>();

            builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
            builder.Services.AddSingleton<ICategoryService, CategoryManager>();

            //add Identity IOS container
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>().AddEntityFrameworkStores<BAMLibraryContext>();
            builder.Services.AddDbContext<BAMLibraryContext>();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.IsEssential = true;
            });
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Home/NotFound";
                options.SlidingExpiration = true;
            });

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

            //IOS container'ý çaðýrma
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();


        }
    }
}