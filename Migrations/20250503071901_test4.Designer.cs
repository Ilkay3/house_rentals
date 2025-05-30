﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using house_rentals.Date;

#nullable disable

namespace House_Rentals.Migrations
{
    [DbContext(typeof(HouseRentalsDBContext))]
    [Migration("20250503071901_test4")]
    partial class test4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("house_rentals.Date.Models.Amenity", b =>
                {
                    b.Property<int>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AmenityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.HasKey("AmenityId");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("HouseId");

                    b.HasIndex("TenantId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("house_rentals.Date.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("house_rentals.Date.Models.House", b =>
                {
                    b.Property<int>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("HouseId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("DOUBLE");

                    b.HasKey("HouseId");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("house_rentals.Date.Models.House_Amenity", b =>
                {
                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("HouseId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("House_Amenities");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OwnerId"));

                    b.Property<string>("EGN")
                        .IsRequired()
                        .HasColumnType("VarChar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TenantId"));

                    b.Property<string>("EGN")
                        .IsRequired()
                        .HasColumnType("VarChar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Booking", b =>
                {
                    b.HasOne("house_rentals.Date.Models.House", "House")
                        .WithMany("Bookings")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("house_rentals.Date.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("house_rentals.Date.Models.House", b =>
                {
                    b.HasOne("house_rentals.Date.Models.City", "City")
                        .WithMany("Houses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("house_rentals.Date.Models.Owner", "Owner")
                        .WithMany("Houses")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("house_rentals.Date.Models.House_Amenity", b =>
                {
                    b.HasOne("house_rentals.Date.Models.Amenity", "Amenity")
                        .WithMany("House_Amenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("house_rentals.Date.Models.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("House");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Payment", b =>
                {
                    b.HasOne("house_rentals.Date.Models.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Amenity", b =>
                {
                    b.Navigation("House_Amenities");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Booking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("house_rentals.Date.Models.City", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("house_rentals.Date.Models.House", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("house_rentals.Date.Models.Owner", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}
