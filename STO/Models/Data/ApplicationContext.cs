using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Client {  get; set; } 
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Worker> Worker { get; set; } 
        public DbSet<Services> Services { get; set; }
        public DbSet<Problems> Problems { get; set; }
        public DbSet<Order> Order { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=STOapp1;Username=postgres;Password=mypassword");
        }
    }
}
