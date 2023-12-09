using Geschäft.Application;
using Geschäft.Application.Contracts.Product;
using Geschäft.Application.Contracts.ProductCategory;
using Geschäft.Domain.ProductAgg;
using Geschäft.Domain.ProductCategoryAgg;
using Geschäft.Infrastracture.EFCore;
using Geschäft.Infrastracture.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace KleinGeschäft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            builder.Services.AddTransient<IProductApplication, ProductApplication>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();

            var connectionString = builder.Configuration.GetConnectionString("EFCoreGeschäft");
            builder.Services.AddDbContext<GeschäftContext>(x => x.UseSqlServer(connectionString));

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