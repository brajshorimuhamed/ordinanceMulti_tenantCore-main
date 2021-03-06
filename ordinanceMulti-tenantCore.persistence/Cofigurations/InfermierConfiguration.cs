using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.persistence.Cofigurations
{
    public class InfermierConfiguration : IEntityTypeConfiguration<Infermier>
    {
        public void Configure(EntityTypeBuilder<Infermier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Infermier_FirstName)
                .HasColumnName("Infermier_FirstName")
                .IsRequired();

            builder.Property(x => x.Infermier_LastName)
                .HasColumnName("Infermier_LastName")
                .IsRequired();

            builder.Property(x => x.Infermier_NrPhone)
                .HasColumnName("Infermier_NrPhone")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Infermier_Address)
                .HasColumnName("Infermier_Address")
                .IsRequired();

            builder.ToTable("Infermiers");
        }
    }
}
