using Microsoft.EntityFrameworkCore;
using ordinanceMulti_tenantCore.application.Interfaces;
using ordinanceMulti_tenantCore.domain.Entities;
using ordinanceMulti_tenantCore.persistence.Cofigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.persistence
{
    public class Ordinance_TenantDbContext : DbContext, IOrdinance_TenantDbContext
    {
        public Ordinance_TenantDbContext(DbContextOptions<Ordinance_TenantDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Infermier> Infermiers { get; set; }

        public int SaveChangesAsync()
        {
            return SaveChanges();
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new InfermierConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
