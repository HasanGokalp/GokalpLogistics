﻿// <auto-generated />
using System;
using GokalpLogistics.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GokalpLogistics.Persistence.Migrations
{
    [DbContext(typeof(GokalpLogisticsContext))]
    [Migration("20230823134520_FIRST")]
    partial class FIRST
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GokalpLogistics.Domain.Concrete.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("IsDeleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("SURNAME");

                    b.Property<int>("TruckId")
                        .HasColumnType("int")
                        .HasColumnName("TRUCK_ID");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id");

                    b.ToTable("DRIVER", (string)null);
                });

            modelBuilder.Entity("GokalpLogistics.Domain.Concrete.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasDefaultValueSql("0");

                    b.Property<int>("Lat")
                        .HasColumnType("integer")
                        .HasColumnName("LAT");

                    b.Property<int>("Lng")
                        .HasColumnType("integer")
                        .HasColumnName("LNG");

                    b.Property<string>("TruckModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("TRUCKMODEL");

                    b.Property<string>("TruckName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("TRUCKNAME");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.ToTable("TRUCK", (string)null);
                });

            modelBuilder.Entity("GokalpLogistics.Domain.Concrete.Truck", b =>
                {
                    b.HasOne("GokalpLogistics.Domain.Concrete.Driver", "Driver")
                        .WithOne("Truck")
                        .HasForeignKey("GokalpLogistics.Domain.Concrete.Truck", "DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("GokalpLogistics.Domain.Concrete.Driver", b =>
                {
                    b.Navigation("Truck")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}