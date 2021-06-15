
using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Data
{
    public partial class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<IPO> IPOs { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<FilterSubscription> FilterSubscriptions { get; set; }
        public DbSet<IPOExchange> IPOExchanges { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=IpoV3;Trusted_Connection=True;", b => b.MigrationsAssembly("Entitites"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<IPOExchange>((entity) => {
                entity.HasKey(ie => new { ie.Id,ie.IPOId, ie.ExchangeId });
                entity.HasOne(ie => ie.IPO).WithMany(ipo => ipo.IPOExchanges).HasForeignKey(ie => ie.IPOId);
                entity.HasOne(ie => ie.Exchange).WithMany(exc => exc.IPOExchanges).HasForeignKey(ie => ie.ExchangeId);
            });

            modelBuilder.Entity<IPO>((entity) =>
            {
                entity.HasKey(ipo => ipo.Id);
                entity.HasOne(ipo => ipo.Subscription).WithOne(sub => sub.IPO).HasForeignKey<IPO>(ipo => ipo.SubscriptionId);
            });

            modelBuilder.Entity<User>((entity) =>
            {
                entity.HasKey(user => user.Id);
                entity.HasOne(user => user.FilterSubscription).WithOne(fsub => fsub.User).HasForeignKey<User>(user => user.FilterSubscriptionId);
            });

            modelBuilder.Entity<Subscription>((entity) =>
            {
                entity.Property(sub => sub.NonInstitutional).HasDefaultValue(0.0f);
                entity.Property(sub => sub.QualifiedInstitutional).HasDefaultValue(0.0f);
                entity.Property(sub => sub.Total).HasDefaultValue(0.0f);
                entity.Property(sub => sub.Others).HasDefaultValue(0.0f);
                entity.Property(sub => sub.Employee).HasDefaultValue(0.0f);
            });

            modelBuilder.Entity<FilterSubscription>((entity) =>
            {
                entity.Property(sub => sub.MinNonInstitutional).HasDefaultValue(0.0f);
                entity.Property(sub => sub.MinQualifiedInstitutional).HasDefaultValue(0.0f);
                entity.Property(sub => sub.MinTotal).HasDefaultValue(0.0f);
                entity.Property(sub => sub.MinOthers).HasDefaultValue(0.0f);
                entity.Property(sub => sub.MinEmployee).HasDefaultValue(0.0f);

            });
        }
    }
}
