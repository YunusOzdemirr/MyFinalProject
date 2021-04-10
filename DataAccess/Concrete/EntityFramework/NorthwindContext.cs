using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context:Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
            //for mac
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Northwind;User=sa;Password=Password123@jkl#;");
           // optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Northwind;User=sa;Password=Password123@jkl#; Encrypt=True;");
        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OperationClaim> OperationClaims{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims{ get; set; }       
    }
}
