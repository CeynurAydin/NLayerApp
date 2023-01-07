using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfugation()); tek başına biri configure edilmek istenildiğinde bu şekilde yazılabilir.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
            //seeddata mızı AppDbcontext içinde bu şekilde de tanımlayabiliriz. 
            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature
                {   
                    Id=1,
                    ProductId=1,
                    Color="Mavi",
                    Height=100,
                    Width=200
                },
                new ProductFeature
                {
                    Id = 2,
                    ProductId = 2,
                    Color = "Kırmızı",
                    Height = 200,
                    Width = 200
                },
                 new ProductFeature
                 {
                     Id = 3,
                     ProductId = 3,
                     Color = "Yeşil",
                     Height = 300,
                     Width = 300
                 } );
            
            base.OnModelCreating(modelBuilder);

        }

       
    }
   
    
}
