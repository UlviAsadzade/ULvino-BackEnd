using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Variaty> Variaties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }



    }
}
