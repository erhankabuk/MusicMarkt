using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class MarktContextSeed
    {
        public static async Task SeedAsync(MarktContext db)
        {
            //Check database
            if (await db.Categories.AnyAsync() || await db.Brands.AnyAsync() || await db.Products.AnyAsync()) return;

            // Add Categories
            var guitar = new Category() { Name = "Guitar" };
            var baglama = new Category() { Name = "Baglama" };
            var piano = new Category() { Name = "Piano" };
            db.AddRange(guitar, baglama, piano);
            await db.SaveChangesAsync();

            // Add Brands
            var gibson = new Brand() { Name = "Gibson" };
            var customBaglama = new Brand() { Name = "Custom Baglama" };
            var yamaha = new Brand() { Name = "Yamaha" };
            db.AddRange(gibson, customBaglama, yamaha);
            await db.SaveChangesAsync();

            // Add Products
            Product[] products = {
            new Product() { Name = "Guitar 1", Price = 12.706m, PictureUri = "1.jpg", Brand = gibson, Category =guitar},
            new Product() { Name = "Guitar 2", Price = 45.564m, PictureUri = "2.jpg", Brand = gibson, Category =guitar},
            new Product() { Name = "Guitar 3", Price = 73.370m, PictureUri = "3.jpg", Brand = gibson, Category =guitar},
            new Product() { Name = "Guitar 4", Price = 67.638m, PictureUri = "4.jpg", Brand = gibson, Category =guitar},
            new Product() { Name = "Baglama 1", Price = 12.509m, PictureUri = "5.jpg", Brand =customBaglama , Category =baglama},
            new Product() { Name = "Baglama 2", Price = 8.085m, PictureUri = "6.jpg", Brand =customBaglama , Category =baglama},
            new Product() { Name = "Baglama 3", Price = 4.576m, PictureUri = "7.jpg", Brand =customBaglama , Category =baglama},
            new Product() { Name = "Baglama 4", Price = 4.576m, PictureUri = "8.jpg", Brand =customBaglama , Category =baglama},
            new Product() { Name = "Piano 1", Price = 1047.974m, PictureUri = "9.jpg", Brand = yamaha, Category =piano},
            new Product() { Name = "Piano 2", Price = 137.691m, PictureUri = "10.jpg", Brand =yamaha , Category =piano},
            new Product() { Name = "Piano 3", Price = 135.345m, PictureUri = "11.jpg", Brand =yamaha , Category =piano},
            new Product() { Name = "Piano 4", Price = 102.239m, PictureUri = "12.jpg", Brand =yamaha , Category =piano}
        };
            db.AddRange(products);
            await db.SaveChangesAsync();
        }
    }
}
