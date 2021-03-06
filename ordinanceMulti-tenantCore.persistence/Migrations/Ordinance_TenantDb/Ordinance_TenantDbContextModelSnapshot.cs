﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ordinanceMulti_tenantCore.persistence;

namespace ordinanceMulti_tenantCore.persistence.Migrations.Ordinance_TenantDb
{
    [DbContext(typeof(Ordinance_TenantDbContext))]
    partial class Ordinance_TenantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ordinanceMulti_tenantCore.domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Doctor_Address")
                        .IsRequired()
                        .HasColumnName("Doctor_Address");

                    b.Property<string>("Doctor_FirstName")
                        .IsRequired()
                        .HasColumnName("Doctor_FirstName");

                    b.Property<string>("Doctor_LastName")
                        .IsRequired()
                        .HasColumnName("Doctor_LastName");

                    b.Property<int>("Doctor_NrPhone")
                        .HasColumnName("Doctor_NrPhone")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ordinanceMulti_tenantCore.domain.Entities.Infermier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Infermier_Address")
                        .IsRequired()
                        .HasColumnName("Infermier_Address");

                    b.Property<string>("Infermier_FirstName")
                        .IsRequired()
                        .HasColumnName("Infermier_FirstName");

                    b.Property<string>("Infermier_LastName")
                        .IsRequired()
                        .HasColumnName("Infermier_LastName");

                    b.Property<int>("Infermier_NrPhone")
                        .HasColumnName("Infermier_NrPhone")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Infermiers");
                });
#pragma warning restore 612, 618
        }
    }
}