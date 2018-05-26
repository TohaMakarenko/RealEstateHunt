using Microsoft.EntityFrameworkCore;
using System.Linq;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data
{
    public class RehDbContext : DbContext
    {
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<ContactCommunicationEntity> ContactCommunications { get; set; }
        public DbSet<ContractEntity> Contracts { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<OfferEntity> Offers { get; set; }
        public DbSet<RealEstateEntity> RealEstates { get; set; }
        public DbSet<RealEstateTypeEntity> RealEstateTypes { get; set; }
        public DbSet<UserEntity> Users { get; set; }

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
            modelBuilder.Entity<UserEntity>()
               .HasIndex(u => u.Name)
               .IsUnique();

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Phone)
                .IsUnique();

            modelBuilder.Entity<ContactEntity>()
                .HasIndex(c => c.BankAccountNumber)
                .IsUnique();

            modelBuilder.Entity<EmployeeEntity>()
                .HasIndex(e => e.ContactId)
                .IsUnique();

            modelBuilder.Entity<ContactCommunicationEntity>()
                .HasIndex(cc => cc.Value);
        }

        protected virtual void CreateForeignKeys(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.City)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.District)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ContactCommunicationEntity>()
                .HasOne(cc => cc.Contact)
                .WithMany(c => c.ContactCommunications)
                .HasForeignKey(cc => cc.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContractEntity>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<ContractEntity>()
                .HasOne(c => c.Manager)
                .WithMany(m => m.Contracts)
                .HasForeignKey(c => c.ManagerId);

            modelBuilder.Entity<ContractEntity>()
                .HasOne(d => d.Offer)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.OfferId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RealEstateEntity>()
                .HasOne(re => re.City)
                .WithMany(c => c.RealEstates)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RealEstateEntity>()
                .HasOne(re => re.District)
                .WithMany(c => c.RealEstates)
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DistrictEntity>()
                .HasOne(d => d.City)
                .WithMany(c => c.Districts)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OfferEntity>()
                .HasOne(d => d.RealEstate)
                .WithMany(c => c.Offers)
                .HasForeignKey(c => c.RealEstateId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<OfferEntity>()
                .HasOne(d => d.Contact)
                .WithMany(c => c.Offers)
                .HasForeignKey(c => c.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
