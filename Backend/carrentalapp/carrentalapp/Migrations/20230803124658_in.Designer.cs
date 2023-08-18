﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using carrentalapp.Data;

#nullable disable

namespace carrentalapp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230803124658_in")]
    partial class @in
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("carrentalapp.Model.Booking", b =>
                {
                    b.Property<long>("booking_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("booking_id"));

                    b.Property<int>("ammt")
                        .HasColumnType("int");

                    b.Property<long?>("car_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("rentalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("returndate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("user_no")
                        .HasColumnType("bigint");

                    b.HasKey("booking_id");

                    b.HasIndex("car_id");

                    b.HasIndex("user_no");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("carrentalapp.Model.Cancel", b =>
                {
                    b.Property<long>("booking_id")
                        .HasColumnType("bigint");

                    b.Property<int>("ammt")
                        .HasColumnType("int");

                    b.Property<long?>("car_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("carid")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("rentalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("returndate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("user_no")
                        .HasColumnType("bigint");

                    b.Property<long?>("user_no1")
                        .HasColumnType("bigint");

                    b.HasKey("booking_id");

                    b.HasIndex("carid");

                    b.HasIndex("user_no1");

                    b.ToTable("Cancels");
                });

            modelBuilder.Entity("carrentalapp.Model.Car", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("car_ac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_brnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("car_milage")
                        .HasColumnType("int");

                    b.Property<int?>("car_model")
                        .HasColumnType("int");

                    b.Property<string>("car_nm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("car_rate")
                        .HasColumnType("int");

                    b.Property<string>("car_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_varient")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("carrentalapp.Model.User", b =>
                {
                    b.Property<long>("user_no")
                        .HasColumnType("bigint");

                    b.Property<string>("user_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("user_adhar")
                        .HasColumnType("bigint");

                    b.Property<string>("user_city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("user_dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_nm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("user_zip")
                        .HasColumnType("int");

                    b.HasKey("user_no");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("carrentalapp.Model.Booking", b =>
                {
                    b.HasOne("carrentalapp.Model.Car", "car")
                        .WithMany("Bookings")
                        .HasForeignKey("car_id");

                    b.HasOne("carrentalapp.Model.User", "user")
                        .WithMany("Bookings")
                        .HasForeignKey("user_no");

                    b.Navigation("car");

                    b.Navigation("user");
                });

            modelBuilder.Entity("carrentalapp.Model.Cancel", b =>
                {
                    b.HasOne("carrentalapp.Model.Car", "car")
                        .WithMany()
                        .HasForeignKey("carid");

                    b.HasOne("carrentalapp.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("user_no1");

                    b.Navigation("car");

                    b.Navigation("user");
                });

            modelBuilder.Entity("carrentalapp.Model.Car", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("carrentalapp.Model.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}