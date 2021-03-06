using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.persistence.Cofigurations
{
    public class OrdinanceConfiguration : IEntityTypeConfiguration<Ordinance>
    {
        public void Configure(EntityTypeBuilder<Ordinance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Ordinance_Name)
                .HasColumnName("Ordinance_Name")
                .IsRequired();

            builder.Property(x => x.Sector)
                .HasColumnName("Sector")
                .IsRequired();

            builder.Property(x => x.Ordinance_Address)
                .HasColumnName("Ordinance_Address")
                .IsRequired();

            builder.Property(x => x.TenantId)
                .HasColumnName("TenandId")
                .IsRequired();

            builder.ToTable("Ordinances");
        }
    }
}
