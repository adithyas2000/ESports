﻿// <auto-generated />
using System;
using ESports.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESports.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221015143128_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ESports.Models.PlayersBid", b =>
                {
                    b.Property<int>("TrophyID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("TeamId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<int>("BidAmount")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("TrophyID", "TeamId");

                    b.ToTable("PlayersBids");
                });

            modelBuilder.Entity("ESports.Models.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
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

                    b.Property<bool>("isClosed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Trophies");
                });

            modelBuilder.Entity("ESports.Models.TrophyRegistration", b =>
                {
                    b.Property<int>("TrophyID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("PlayerNIC")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<int>("BaseFee")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ESports.Models.TrophyTeam", b =>
                {
                    b.Property<int>("TrophyID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("TeamId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<int>("MaxPrice")
                        .HasColumnType("int");

                    b.Property<int>("SpentAmount")
                        .HasColumnType("int");

                    b.HasKey("TrophyID", "TeamId");

                    b.ToTable("TrophyTeams");
                });
#pragma warning restore 612, 618
        }
    }
}