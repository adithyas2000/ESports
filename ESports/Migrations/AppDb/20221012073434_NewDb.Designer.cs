﻿// <auto-generated />
using System;
using ESports.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESports.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221012073434_NewDb")]
    partial class NewDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ESports.Models.Player", b =>
                {
                    b.Property<string>("PlayerNIC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CurrentTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerAge")
                        .HasColumnType("int");

                    b.Property<string>("PlayerFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerHand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerNIC");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ESports.Models.Trophy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trophies");
                });

            modelBuilder.Entity("ESports.Models.TrophyRegistration", b =>
                {
                    b.Property<string>("TrophyID")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("PlayerNIC")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("CurrentTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerAge")
                        .HasColumnType("int");

                    b.Property<string>("PlayerFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerHand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrophyID", "PlayerNIC");

                    b.ToTable("TrophyRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
