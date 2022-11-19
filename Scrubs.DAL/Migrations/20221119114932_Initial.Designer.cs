﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Scrubs.DAL;

#nullable disable

namespace Scrubs.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221119114932_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Scrubs.Domain.Entity.AppointmentDoctor", b =>
                {
                    b.Property<DateTime>("DateOfFinishAppointmentWithDoctor")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfStartAppointmentWithDoctor")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FreeTimeOfDoctor")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("integer");

                    b.Property<int>("IdPatient")
                        .HasColumnType("integer");

                    b.ToTable("AppointmentDoctors");
                });

            modelBuilder.Entity("Scrubs.Domain.Entity.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Scrubs.Domain.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Scrubs.Domain.Entity.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Scrubs.Domain.Entity.TimeTable", b =>
                {
                    b.Property<DateTime>("FinishOfWorkDayDoctor")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdOfDoctor")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartOfWorkDayDoctor")
                        .HasColumnType("timestamp with time zone");

                    b.ToTable("TimeTables");
                });

            modelBuilder.Entity("Scrubs.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}