﻿// <auto-generated />
using AuthSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthSystem.Migrations.Employee
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthSystem.Models.Employee", b =>
                {
                    b.Property<int>("Eid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Eid"));

                    b.Property<string>("Eaddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Egender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Eid");

                    b.ToTable("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
