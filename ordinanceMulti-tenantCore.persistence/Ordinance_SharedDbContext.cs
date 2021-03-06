using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ordinanceMulti_tenantCore.application.Interfaces;
using ordinanceMulti_tenantCore.domain.Entities;
using ordinanceMulti_tenantCore.persistence.Cofigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.persistence
{
    public class Ordinance_SharedDbContext : IdentityDbContext<User, Role, string>, IOrdinance_SharedDbContext
    {
        public Ordinance_SharedDbContext(DbContextOptions<Ordinance_SharedDbContext> options) : base(options)
        {

        }

        public DbSet<Ordinance> Ordinances { get; set; }
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; } 
        public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }

        public int SaveChangesAsync()
        {
            return SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrdinanceConfiguration());

            Ordinance_SharedDbInitializer.Initialize(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
