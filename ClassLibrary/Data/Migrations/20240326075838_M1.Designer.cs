﻿// <auto-generated />
using System;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassLibrary.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240326075838_M1")]
    partial class M1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("ClassLibrary.Models.Manifest", b =>
                {
                    b.Property<int>("ManifestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MemberId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ManifestId", "MemberId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TripId");

                    b.ToTable("Manifest", (string)null);

                    b.HasData(
                        new
                        {
                            ManifestId = 1,
                            MemberId = "6c136e26-2431-4b04-acb7-6d354abe5e8e",
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7235),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7238),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Notes = "I'm driving",
                            TripId = 1
                        },
                        new
                        {
                            ManifestId = 2,
                            MemberId = "dbe2cc4b-27c2-44aa-af5d-a4289cefaef3",
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7251),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7268),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Notes = "I'm driving",
                            TripId = 2
                        },
                        new
                        {
                            ManifestId = 3,
                            MemberId = "6c136e26-2431-4b04-acb7-6d354abe5e8e",
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7272),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7275),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Notes = "I'm driving",
                            TripId = 3
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Member", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbe2cc4b-27c2-44aa-af5d-a4289cefaef3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ab95c4e4-8fb9-499a-ad4e-10425fb3690e",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "b@b.b",
                            EmailConfirmed = true,
                            FirstName = "Test",
                            LastName = "User1",
                            LockoutEnabled = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NormalizedEmail = "B@B.B",
                            NormalizedUserName = "B@B.B",
                            PasswordHash = "AQAAAAIAAYagAAAAEJA76L/+8NIJvQcHVofMRPjUJ+hhM4kUUkJ0btPrjK33PlGDXpQpQSoq+xWrIrSeIQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "76f9d4fc-fe84-4b9a-93eb-b1fbd2c271ad",
                            TwoFactorEnabled = false,
                            UserName = "b@b.b"
                        },
                        new
                        {
                            Id = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "36ce9530-e315-4061-8991-e4d006751d0a",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "c@c.c",
                            EmailConfirmed = true,
                            FirstName = "Test",
                            LastName = "Owner",
                            LockoutEnabled = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NormalizedEmail = "C@C.C",
                            NormalizedUserName = "C@C.C",
                            PasswordHash = "AQAAAAIAAYagAAAAEFTLVHN7e+7yL2jWoRoi7hsqq81Xf2xp1QUqhDzsG4r0NtB48WNwfWLT3xM+7nafQw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0c157a1a-3242-4091-8d94-0a57c5cae89f",
                            TwoFactorEnabled = false,
                            UserName = "c@c.c"
                        },
                        new
                        {
                            Id = "6c136e26-2431-4b04-acb7-6d354abe5e8e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "14fdb97c-da13-44f8-b752-8b052d5fa4b8",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "d@d.d",
                            EmailConfirmed = true,
                            FirstName = "Test",
                            LastName = "Passenger",
                            LockoutEnabled = false,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NormalizedEmail = "D@D.D",
                            NormalizedUserName = "D@D.D",
                            PasswordHash = "AQAAAAIAAYagAAAAEMsZZwM1d545OEz6ZweOoSEmLmBpljFa0OXmRLPo42ms10FTQ0dC2bjMmVMPpFeFIQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "680e0775-d00e-48d0-9726-042a296ad4ab",
                            TwoFactorEnabled = false,
                            UserName = "d@d.d"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("MeetingAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly?>("Time")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TripId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Trip", (string)null);

                    b.HasData(
                        new
                        {
                            TripId = 1,
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7117),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Date = new DateOnly(2021, 12, 25),
                            DestinationAddress = "123 Main St, Anytown, USA",
                            MeetingAddress = "456 Elm St, Anytown, USA",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7121),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Time = new TimeOnly(12, 0, 0),
                            VehicleId = 1
                        },
                        new
                        {
                            TripId = 2,
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7136),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Date = new DateOnly(2022, 1, 12),
                            DestinationAddress = "321 Knight St, Anytown, USA",
                            MeetingAddress = "789 Cambie St, Anytown, USA",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7139),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Time = new TimeOnly(14, 30, 0),
                            VehicleId = 2
                        },
                        new
                        {
                            TripId = 3,
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7152),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Date = new DateOnly(2022, 1, 24),
                            DestinationAddress = "8 Moody St, Anyville, USA",
                            MeetingAddress = "99 Hastings St, Anytown, USA",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7155),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Time = new TimeOnly(8, 0, 0),
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .HasColumnType("TEXT");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NumberOfSeats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VehicleType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("VehicleId");

                    b.HasIndex("Id");

                    b.ToTable("Vehicle", (string)null);

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6885),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Make = "Tesla",
                            MemberId = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Model = "Model 3",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6966),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            NumberOfSeats = 5,
                            VehicleType = "Electric",
                            Year = 2021
                        },
                        new
                        {
                            VehicleId = 2,
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6982),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Make = "Tesla",
                            MemberId = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Model = "Model S",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6985),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            NumberOfSeats = 5,
                            VehicleType = "Electric",
                            Year = 2021
                        },
                        new
                        {
                            VehicleId = 3,
                            Created = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6991),
                            CreatedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Make = "Tesla",
                            MemberId = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            Model = "Model X",
                            Modified = new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7000),
                            ModifiedBy = "b874ec6d-884c-4694-b092-66a03029e8c7",
                            NumberOfSeats = 5,
                            VehicleType = "Electric",
                            Year = 2021
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ClassLibrary.Models.Manifest", b =>
                {
                    b.HasOne("ClassLibrary.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("ClassLibrary.Models.Trip", b =>
                {
                    b.HasOne("ClassLibrary.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ClassLibrary.Models.Vehicle", b =>
                {
                    b.HasOne("ClassLibrary.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ClassLibrary.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ClassLibrary.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ClassLibrary.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}