﻿// <auto-generated />
using System;
using AS_EFShelterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AS_EFShelterData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AS_Core.DomainModel.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("AnimalType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Castrated")
                        .HasColumnType("bit");

                    b.Property<int>("ChildFriendly")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstimatedAge")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonGivenAway")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 2,
                            AnimalType = 0,
                            Birthdate = new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Castrated = true,
                            ChildFriendly = 0,
                            Description = "Good boi",
                            EstimatedAge = 2,
                            Gender = " ",
                            Name = "Doggo",
                            Picture = "Goodboi.png",
                            Race = "Best Bois",
                            ReasonGivenAway = "Too good a boi"
                        },
                        new
                        {
                            ID = 2,
                            Age = 2,
                            AnimalType = 1,
                            Birthdate = new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Castrated = true,
                            ChildFriendly = 0,
                            Description = "Good boi",
                            EstimatedAge = 2,
                            Gender = " ",
                            Name = "Garfield",
                            Picture = "Garfield.png",
                            Race = "Garfields",
                            ReasonGivenAway = "Ate too much lasagna"
                        });
                });

            modelBuilder.Entity("AS_Core.DomainModel.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StayID")
                        .HasColumnType("int");

                    b.Property<string>("WrittenBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("StayID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Content = "Cool doggo",
                            Date = new DateTime(2020, 10, 21, 22, 23, 8, 93, DateTimeKind.Local).AddTicks(8461),
                            StayID = 1,
                            WrittenBy = "Barry"
                        },
                        new
                        {
                            ID = 2,
                            Content = "Ate all the lasagna",
                            Date = new DateTime(2020, 10, 21, 22, 23, 8, 98, DateTimeKind.Local).AddTicks(4227),
                            StayID = 2,
                            WrittenBy = "Barry"
                        });
                });

            modelBuilder.Entity("AS_Core.DomainModel.Lodging", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalType")
                        .HasColumnType("int");

                    b.Property<int>("CurrentCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LodgingType")
                        .HasColumnType("int");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Lodgings");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AnimalType = 0,
                            CurrentCapacity = 10,
                            Description = "Grote opvang voor Honden ",
                            LodgingType = 0,
                            MaxCapacity = 100
                        },
                        new
                        {
                            ID = 2,
                            AnimalType = 1,
                            CurrentCapacity = 10,
                            Description = "Grote opvang voor Katten ",
                            LodgingType = 0,
                            MaxCapacity = 100
                        });
                });

            modelBuilder.Entity("AS_Core.DomainModel.Stay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdoptedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AdoptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AnimalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CanBeAdopted")
                        .HasColumnType("bit");

                    b.Property<int>("LodgingLocationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AnimalID");

                    b.HasIndex("LodgingLocationID");

                    b.ToTable("Stays");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AdoptedBy = "",
                            AnimalID = 1,
                            ArrivalDate = new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CanBeAdopted = true,
                            LodgingLocationID = 1
                        },
                        new
                        {
                            ID = 2,
                            AdoptedBy = "",
                            AnimalID = 2,
                            ArrivalDate = new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CanBeAdopted = true,
                            LodgingLocationID = 2
                        });
                });

            modelBuilder.Entity("AS_Core.DomainModel.Treatment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Costs")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredAge")
                        .HasColumnType("int");

                    b.Property<int>("StayID")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StayID");

                    b.ToTable("Treatments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Costs = 100.50m,
                            Date = new DateTime(2020, 10, 21, 22, 23, 8, 98, DateTimeKind.Local).AddTicks(9960),
                            Description = "Inenting voor ziekte x",
                            DoneBy = "Some Person",
                            RequiredAge = 1,
                            StayID = 1,
                            TreatmentType = 2
                        },
                        new
                        {
                            ID = 2,
                            Costs = 100.50m,
                            Date = new DateTime(2020, 10, 21, 22, 23, 8, 99, DateTimeKind.Local).AddTicks(1293),
                            Description = "Removed lasagna from stomach",
                            DoneBy = "Some Person",
                            RequiredAge = 1,
                            StayID = 2,
                            TreatmentType = 3
                        });
                });

            modelBuilder.Entity("AS_Core.DomainModel.Comment", b =>
                {
                    b.HasOne("AS_Core.DomainModel.Stay", "Stay")
                        .WithMany("Comments")
                        .HasForeignKey("StayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AS_Core.DomainModel.Stay", b =>
                {
                    b.HasOne("AS_Core.DomainModel.Animal", "Animal")
                        .WithMany("Stays")
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AS_Core.DomainModel.Lodging", "LodgingLocation")
                        .WithMany("Stays")
                        .HasForeignKey("LodgingLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AS_Core.DomainModel.Treatment", b =>
                {
                    b.HasOne("AS_Core.DomainModel.Stay", "Stay")
                        .WithMany("Treatments")
                        .HasForeignKey("StayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
