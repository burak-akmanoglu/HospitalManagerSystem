using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BURAK;database=HospitalManagerSystem;integrated security=true");
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Storehouse> Storehouses { get; set; }
        public DbSet<User> Users { get; set; }
       

    }
}
