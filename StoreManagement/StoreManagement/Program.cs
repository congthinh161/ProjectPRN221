using Microsoft.EntityFrameworkCore;
using StoreManagement.IService;
using StoreManagement.Models;
using StoreManagement.Services;
using System.Security.Cryptography.X509Certificates;

namespace StoreManagement
{
    public class Program
    {
        public IConfiguration Configuration { get; }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //var Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<WebContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Web")));
            builder.Services.AddScoped<IProductService, ProductServices>();
            builder.Services.AddScoped<ICategoryService, CategoryServices>();
            
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}