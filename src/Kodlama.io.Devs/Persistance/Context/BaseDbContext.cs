using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgLanguage> ProgLanguages { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //   base.OnConfiguring(
            //       optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIoDevsConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgLanguage>(a =>
            {
                a.ToTable("ProgLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Frameworks);
            });
            modelBuilder.Entity<Framework>(a =>
            {
                a.ToTable("Frameworks").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgLanguageId).HasColumnName("ProgLanguageId");
                a.HasOne(p => p.ProgLanguage);
            });
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(u => u.Id).HasColumnName("Id");
                a.Property(u => u.FirstName).HasColumnName("FirstName");
                a.Property(u => u.LastName).HasColumnName("LastName");
                a.Property(u => u.Email).HasColumnName("Email");
                a.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                a.Property(u => u.Status).HasColumnName("Status");
                a.HasMany(u => u.UserOperationClaims);

            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(p => p.OperationClaim);
                a.HasOne(p => p.User);
            });


            modelBuilder.Entity<Social>(a =>
            {
                a.ToTable("Socials").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Url).HasColumnName("Url");
                a.HasOne(p => p.User);
            });


            ProgLanguage[] ProgLanguageEntitySeeds = { new(1, "BMW"), new(2, "Mercedes") };
            modelBuilder.Entity<ProgLanguage>().HasData(ProgLanguageEntitySeeds);


        }
    }
}
