using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models
{
    public class RehDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CommunicationType> CommunicationTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCommunication> ContactCommunications { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected RehDbContext()
        {
            Database.EnsureCreated();
        }

        public RehDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Phone).IsUnique();
            modelBuilder.Entity<BankAccount>().HasIndex(ba => ba.Number).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.ContactId).IsUnique();
            modelBuilder.Entity<ContactCommunication>().HasIndex(cc => cc.Value);
        }
    }
}
