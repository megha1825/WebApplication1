﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Database.Context;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241030051642_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Database.Entity.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApplication1.Pages.models.Signup", b =>
                {
                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("isactive")
                        .HasColumnType("int");

                    b.HasKey("FirstName");

                    b.ToTable("Signups");
                });

            modelBuilder.Entity("WebApplication1.Pages.models.login", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("logins");
                });

            modelBuilder.Entity("WebApplication1.Pages.models.product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("product_id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_isactive")
                        .HasColumnType("int");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_price")
                        .HasColumnType("int");

                    b.Property<int>("product_quantity")
                        .HasColumnType("int");

                    b.Property<string>("product_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("product_id");

                    b.ToTable("products");
                });
#pragma warning restore 612, 618
        }
    }
}
