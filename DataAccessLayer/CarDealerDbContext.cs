using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options) : base(options) 
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                                   .Where(x => x.State == EntityState.Added ||
                                               x.State == EntityState.Modified);

            foreach (var entrie in entries)
            {
                if (entrie.Entity is IEntity addEntity && entrie.State == EntityState.Added)
                {
                    addEntity.DbCreationDate = DateTime.UtcNow;
                }
                if (entrie.Entity is IEntity updateEntity && entrie.State == EntityState.Modified)
                {
                    updateEntity.DbUpdateDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
      .HasOne(c => c.LegalPerson)
      .WithOne()
      .HasForeignKey<Customer>(c => c.LegalPersonId);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.NaturalPerson)
                .WithOne()
                .HasForeignKey<Customer>(c => c.NaturalPersonId);

            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            NaturalPerson person1 = new NaturalPerson
            {
                Id = Guid.NewGuid(),
                FirstName = "Ion",
                LastName = "Buton",
                DbCreationDate = DateTime.UtcNow
            };
            NaturalPerson person2 = new NaturalPerson
            {
                Id = Guid.NewGuid(),
                FirstName = "Radu",
                LastName = "Bradu",
                DbCreationDate = DateTime.UtcNow
            };
            modelBuilder.Entity<NaturalPerson>().HasData(
                person1,
                person2
            );
            LegalPerson legal1 = new LegalPerson
            {
                Id = Guid.NewGuid(),
                CompanyName = "ABC Inc.",
                RegistrationNumber = 12345,
                DbCreationDate = DateTime.UtcNow
            };
            LegalPerson legal2 = new LegalPerson
            {
                Id = Guid.NewGuid(),
                CompanyName = "XYZ Corp.",
                RegistrationNumber = 67890,
                DbCreationDate = DateTime.UtcNow
            };
            // Seed LegalPersons
            modelBuilder.Entity<LegalPerson>().HasData(
              legal1,
              legal2
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = Guid.NewGuid(),
                    CType = CustomerType.Natural,
                    DbCreationDate = DateTime.UtcNow,
                    NaturalPersonId = person1.Id

                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    CType = CustomerType.Legal,
                    DbCreationDate = DateTime.UtcNow,
                    LegalPersonId = legal2.Id

                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    CType = CustomerType.Natural,
                    DbCreationDate = DateTime.UtcNow,
                    NaturalPersonId = person2.Id

                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    CType = CustomerType.Legal,
                    DbCreationDate = DateTime.UtcNow,
                    LegalPersonId = legal1.Id
                }
            );
        }
    }
}
