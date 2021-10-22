using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Capstone.Models {
    public class PRSDbContext : DbContext {
        //DbSet collections go here

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Requestline> Requestlines { get; set; }
        public object Reviews { get; internal set; }

        public PRSDbContext(DbContextOptions<PRSDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<User>(p => {
                p.ToTable("Users");
                p.HasIndex(u => u.Username).IsUnique(true);

            });

            builder.Entity<Vendor>(p => {
                p.ToTable("Vendors");
                p.HasIndex(u => u.Code).IsUnique(true);

            });

            builder.Entity<Product>(p => {
                p.ToTable("Products");
                p.HasIndex(u => u.PartNbr).IsUnique(true);


            });



        }

    }
}


