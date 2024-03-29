﻿// <auto-generated />
using System;
using McTours.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    [DbContext(typeof(McToursContext))]
    [Migration("20230219121916_TicketConfig")]
    partial class TicketConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("McTours.Domain.BusTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArrivalCityId")
                        .HasColumnType("int");

                    b.Property<int?>("BreakTimeDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(0)");

                    b.Property<int>("DeppartureCityId")
                        .HasColumnType("int");

                    b.Property<int>("EstimatedTravelTime")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("money");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalCityId");

                    b.HasIndex("DeppartureCityId");

                    b.HasIndex("VehicleId");

                    b.ToTable("BusTrip", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalCityId = 2,
                            BreakTimeDuration = 30,
                            Date = new DateTime(2023, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            DeppartureCityId = 1,
                            EstimatedTravelTime = 180,
                            TicketPrice = 150m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArrivalCityId = 1,
                            BreakTimeDuration = 60,
                            Date = new DateTime(2023, 3, 16, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DeppartureCityId = 3,
                            EstimatedTravelTime = 360,
                            TicketPrice = 200m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 3,
                            ArrivalCityId = 5,
                            BreakTimeDuration = 90,
                            Date = new DateTime(2023, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DeppartureCityId = 1,
                            EstimatedTravelTime = 720,
                            TicketPrice = 330m,
                            VehicleId = 3
                        },
                        new
                        {
                            Id = 4,
                            ArrivalCityId = 1,
                            BreakTimeDuration = 90,
                            Date = new DateTime(2023, 3, 18, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            DeppartureCityId = 5,
                            EstimatedTravelTime = 720,
                            TicketPrice = 330m,
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("McTours.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "İstanbul"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bursa"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ankara"
                        },
                        new
                        {
                            Id = 4,
                            Name = "İzmir"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Antalya"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Trabzon"
                        });
                });

            modelBuilder.Entity("McTours.Domain.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Passenger", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1982, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tsubasa",
                            Gender = 1,
                            IdentityNumber = "12345678910",
                            LastName = "Ozora"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1982, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sanae",
                            Gender = 2,
                            IdentityNumber = "12345678910",
                            LastName = "Ozora"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1982, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Kojiro",
                            Gender = 1,
                            IdentityNumber = "23456789101",
                            LastName = "Hyuga"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1982, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Genzo",
                            Gender = 1,
                            IdentityNumber = "34567891012",
                            LastName = "Wakabayashi"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Taro",
                            Gender = 1,
                            IdentityNumber = "45678910123",
                            LastName = "Misaki"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1982, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ken",
                            Gender = 1,
                            IdentityNumber = "56789101234",
                            LastName = "Wakashimazu"
                        });
                });

            modelBuilder.Entity("McTours.Domain.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusTripId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<short>("SeatNumber")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("BusTripId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("McTours.Domain.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("date");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleDefinitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleDefinitionId");

                    b.ToTable("Vehicle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PlateNumber = "34AST001",
                            RegistrationDate = new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "ATS3030121AK",
                            VehicleDefinitionId = 1
                        },
                        new
                        {
                            Id = 2,
                            PlateNumber = "34UK080",
                            RegistrationDate = new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "ATS3546781AK",
                            VehicleDefinitionId = 2
                        },
                        new
                        {
                            Id = 3,
                            PlateNumber = "34CRF19",
                            RegistrationDate = new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "ATS0000459AK",
                            VehicleDefinitionId = 3
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<short>("LineCount")
                        .HasColumnType("smallint");

                    b.Property<int>("SeatingType")
                        .HasColumnType("int");

                    b.Property<int>("Utilities")
                        .HasColumnType("int");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("VehicleDefinition", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FuelType = 2,
                            LineCount = (short)10,
                            SeatingType = 1,
                            Utilities = 11,
                            VehicleModelId = 1,
                            Year = (short)2009
                        },
                        new
                        {
                            Id = 2,
                            FuelType = 1,
                            LineCount = (short)10,
                            SeatingType = 2,
                            Utilities = 219,
                            VehicleModelId = 2,
                            Year = (short)2019
                        },
                        new
                        {
                            Id = 3,
                            FuelType = 2,
                            LineCount = (short)10,
                            SeatingType = 1,
                            Utilities = 75,
                            VehicleModelId = 2,
                            Year = (short)2012
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMake", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MAN"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Isuzu"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Otokar"
                        },
                        new
                        {
                            Id = 5,
                            Name = "BMC"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Iveco"
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModel", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Travego",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tourismo",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fortuna",
                            VehicleMakeId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lions",
                            VehicleMakeId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Novociti",
                            VehicleMakeId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Citibus",
                            VehicleMakeId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Doruk",
                            VehicleMakeId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Kent",
                            VehicleMakeId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "ProCity",
                            VehicleMakeId = 5
                        },
                        new
                        {
                            Id = 10,
                            Name = "Belde",
                            VehicleMakeId = 5
                        },
                        new
                        {
                            Id = 11,
                            Name = "M50",
                            VehicleMakeId = 6
                        });
                });

            modelBuilder.Entity("McTours.Domain.BusTrip", b =>
                {
                    b.HasOne("McTours.Domain.City", "ArrivalCity")
                        .WithMany()
                        .HasForeignKey("ArrivalCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("McTours.Domain.City", "DeppartureCity")
                        .WithMany()
                        .HasForeignKey("DeppartureCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("McTours.Domain.Vehicle", "Vehicle")
                        .WithMany("BusTrips")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ArrivalCity");

                    b.Navigation("DeppartureCity");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("McTours.Domain.Ticket", b =>
                {
                    b.HasOne("McTours.Domain.BusTrip", "BusTrip")
                        .WithMany("Tickets")
                        .HasForeignKey("BusTripId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("McTours.Domain.Passenger", "Passenger")
                        .WithMany("Tickets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BusTrip");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("McTours.Domain.Vehicle", b =>
                {
                    b.HasOne("McTours.Domain.VehicleDefinition", "VehicleDefinition")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleDefinitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleDefinition");
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.HasOne("McTours.Domain.VehicleModel", "VehicleModel")
                        .WithMany("VehicleDefinitons")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.HasOne("McTours.Domain.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("McTours.Domain.BusTrip", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("McTours.Domain.Passenger", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("McTours.Domain.Vehicle", b =>
                {
                    b.Navigation("BusTrips");
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("McTours.Domain.VehicleMake", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.Navigation("VehicleDefinitons");
                });
#pragma warning restore 612, 618
        }
    }
}
