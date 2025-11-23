using demoapiproject.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demoapiproject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


        // this will solve the error 
        //      "Don't pluralize; use THIS EXACT table name."

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // ⭐ Map Employee entity to "Employee" table
        //    modelBuilder.Entity<Employee>()
        //                .ToTable("Employee");
        //} This tells EF Core:


    }

}

