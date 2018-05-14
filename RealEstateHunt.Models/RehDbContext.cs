using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateHunt.Models
{
    public class RehDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCommunication> ContactCommunications { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
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
            base.OnModelCreating(modelBuilder);
            #region indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Phone)
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.BankAccountNumber)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.ContactId)
                .IsUnique();

            modelBuilder.Entity<ContactCommunication>()
                .HasIndex(cc => cc.Value);
            #endregion

            #region Foreign keys settings

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.City)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.District)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ContactCommunication>()
                .HasOne(cc => cc.Contact)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
