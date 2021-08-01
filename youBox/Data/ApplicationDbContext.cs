using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using youBox.Models;

namespace youBox.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Subscriber",
                NormalizedName = "SUBSCRIBER"
            },
            new IdentityRole
            {
                Name="Employee",
                NormalizedName= "EMPLOYEE"
            }
            );
        }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Employee>Employees { get; set; }
    }
}
