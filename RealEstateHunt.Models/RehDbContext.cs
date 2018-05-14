using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            CreateIndexes(modelBuilder);
            CreateForeignKeys(modelBuilder);
        }

        protected virtual void CreateIndexes(ModelBuilder modelBuilder)
        {
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
        }

        protected virtual void CreateForeignKeys(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.City)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.District)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ContactCommunication>()
                .HasOne(cc => cc.Contact)
                .WithMany(c => c.ContactCommunications)
                .HasForeignKey(cc => cc.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Manager)
                .WithMany(m => m.Contracts)
                .HasForeignKey(c => c.ManagerId);

            modelBuilder.Entity<Contract>()
                .HasOne(d => d.Offer)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.OfferId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RealEstate>()
                .HasOne(re => re.City)
                .WithMany(c => c.RealEstates)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RealEstate>()
                .HasOne(re => re.District)
                .WithMany(c => c.RealEstates)
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<District>()
                .HasOne(d => d.City)
                .WithMany(c => c.Districts)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Offer>()
                .HasOne(d => d.RealEstate)
                .WithMany(c => c.Offers)
                .HasForeignKey(c => c.RealEstateId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
