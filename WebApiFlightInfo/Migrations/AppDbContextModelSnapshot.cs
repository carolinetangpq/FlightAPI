﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiFlightInfo.Models;

namespace WebApiFlightInfo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiFlightInfo.Models.Flight", b =>
                {
                    b.Property<string>("flightId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("flightDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("flightDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("flightSource")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("flightId");

                    b.ToTable("Flight");

                    b.HasData(
                        new
                        {
                            flightId = "SIA606",
                            flightDateTime = new DateTime(2023, 11, 4, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            flightDestination = "SEOUL, SOUTH KOREA",
                            flightSource = "SINGAPORE"
                        },
                        new
                        {
                            flightId = "BAW304",
                            flightDateTime = new DateTime(2023, 10, 6, 12, 23, 30, 0, DateTimeKind.Unspecified),
                            flightDestination = "PARIS, FRANCE",
                            flightSource = "LONDON, UNITED KINGDOM"
                        },
                        new
                        {
                            flightId = "TGW24",
                            flightDateTime = new DateTime(2023, 12, 3, 20, 5, 15, 0, DateTimeKind.Unspecified),
                            flightDestination = "MELBOURNE, AUSTRALIA",
                            flightSource = "SINGAPORE"
                        },
                        new
                        {
                            flightId = "EVA218",
                            flightDateTime = new DateTime(2022, 5, 17, 15, 5, 15, 0, DateTimeKind.Unspecified),
                            flightDestination = "TAIPEI, TAIWAN",
                            flightSource = "SEPANG, MALAYSIA"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
