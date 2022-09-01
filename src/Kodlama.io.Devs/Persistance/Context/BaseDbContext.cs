﻿using Domain.Entities;
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
            });



            ProgLanguage[] ProgLanguageEntitySeeds = { new(1, "BMW"), new(2, "Mercedes") };
            modelBuilder.Entity<ProgLanguage>().HasData(ProgLanguageEntitySeeds);


        }
    }
}
