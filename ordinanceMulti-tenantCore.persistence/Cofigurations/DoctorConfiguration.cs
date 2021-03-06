using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ordinanceMulti_tenantCore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ordinanceMulti_tenantCore.persistence.Cofigurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Doctor_FirstName)
                .HasColumnName("Doctor_FirstName")
                .IsRequired();

            builder.Property(x => x.Doctor_LastName)
                .HasColumnName("Doctor_LastName")
                .IsRequired();

            builder.Property(x => x.Doctor_NrPhone)
                .HasColumnName("Doctor_NrPhone")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Doctor_Address)
                .HasColumnName("Doctor_Address")
                .IsRequired();

            builder.ToTable("Doctors");
        }
    }
}
