﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentAttendanceTrackingApp.Data;

#nullable disable

namespace StudentAttendanceTrackingApp.Data.Migrations
{
    [DbContext(typeof(SATDbContext))]
    partial class SATDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentAttendanceTrackingApp.Data.Entities.ApiUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ApiUsers", "satapp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Company = "Tech Solutions",
                            CreaDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            IsDeleted = false,
                            LastName = "Doe",
                            Password = "password123",
                            Phone = "+1234567890",
                            UserName = "jdoe"
                        },
                        new
                        {
                            Id = 2,
                            Company = "Innovatech",
                            CreaDate = new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "alicesmith@example.com",
                            FirstName = "Alice",
                            IsDeleted = false,
                            LastName = "Smith",
                            Password = "securepass456",
                            Phone = "+0987654321",
                            UserName = "asmith"
                        },
                        new
                        {
                            Id = 3,
                            Company = "Future Tech",
                            CreaDate = new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "bobmiller@example.com",
                            FirstName = "Bob",
                            IsDeleted = false,
                            LastName = "Miller",
                            Password = "mypassword789",
                            Phone = "+1122334455",
                            UserName = "bmiller"
                        },
                        new
                        {
                            Id = 4,
                            Company = "Tech Innovators",
                            CreaDate = new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "charliejohnson@example.com",
                            FirstName = "Charlie",
                            IsDeleted = false,
                            LastName = "Johnson",
                            Password = "pass1234",
                            Phone = "+6677889900",
                            UserName = "cjohnson"
                        },
                        new
                        {
                            Id = 5,
                            Company = "NextGen Tech",
                            CreaDate = new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "dianadavis@example.com",
                            FirstName = "Diana",
                            IsDeleted = false,
                            LastName = "Davis",
                            Password = "password321",
                            Phone = "+4455667788",
                            UserName = "ddavis"
                        });
                });

            modelBuilder.Entity("StudentAttendanceTrackingApp.Data.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Lesson", "satapp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6111),
                            IsDeleted = false,
                            Name = "Matematik"
                        },
                        new
                        {
                            Id = 2,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6119),
                            IsDeleted = false,
                            Name = "Fizik"
                        },
                        new
                        {
                            Id = 3,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6120),
                            IsDeleted = false,
                            Name = "Kimya"
                        },
                        new
                        {
                            Id = 4,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6121),
                            IsDeleted = false,
                            Name = "Biyoloji"
                        },
                        new
                        {
                            Id = 5,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6122),
                            IsDeleted = false,
                            Name = "Tarih"
                        },
                        new
                        {
                            Id = 6,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6126),
                            IsDeleted = false,
                            Name = "Coğrafya"
                        },
                        new
                        {
                            Id = 7,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6127),
                            IsDeleted = false,
                            Name = "İngilizce"
                        },
                        new
                        {
                            Id = 8,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6128),
                            IsDeleted = false,
                            Name = "Edebiyat"
                        },
                        new
                        {
                            Id = 9,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6129),
                            IsDeleted = false,
                            Name = "Bilgisayar Bilimleri"
                        },
                        new
                        {
                            Id = 10,
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6132),
                            IsDeleted = false,
                            Name = "Beden Eğitimi"
                        });
                });

            modelBuilder.Entity("StudentAttendanceTrackingApp.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Students", "satapp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1988, 4, 11, 21, 0, 0, 0, DateTimeKind.Utc),
                            City = "Iğdır",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9834),
                            Email = "tuğra.yıldız.88@hotmail.com",
                            FirstName = "Tuğra",
                            IsDeleted = false,
                            LastName = "Yıldız"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2005, 3, 23, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Sakarya",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9854),
                            Email = "hande.derici.05@hotmail.com",
                            FirstName = "Hande",
                            IsDeleted = false,
                            LastName = "Derici"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1998, 11, 27, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Şanlıurfa",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9866),
                            Email = "kaan.yurt.98@hotmail.com",
                            FirstName = "Kaan",
                            IsDeleted = false,
                            LastName = "Yurt"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2012, 12, 4, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Bayburt",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9878),
                            Email = "yağmur.kaya.12@hotmail.com",
                            FirstName = "Yağmur",
                            IsDeleted = false,
                            LastName = "Kaya"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1980, 10, 27, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Kilis",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9888),
                            Email = "hande.boz.80@hotmail.com",
                            FirstName = "Hande",
                            IsDeleted = false,
                            LastName = "Boz"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1975, 12, 22, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "İzmir",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9902),
                            Email = "yeşim.yüce.75@hotmail.com",
                            FirstName = "Yeşim",
                            IsDeleted = false,
                            LastName = "Yüce"
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1973, 5, 31, 21, 0, 0, 0, DateTimeKind.Utc),
                            City = "Nevşehir",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9911),
                            Email = "cansu.yurt.73@hotmail.com",
                            FirstName = "Cansu",
                            IsDeleted = false,
                            LastName = "Yurt"
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1972, 9, 7, 21, 0, 0, 0, DateTimeKind.Utc),
                            City = "Mardin",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9921),
                            Email = "mehmet.ergen.72@hotmail.com",
                            FirstName = "Mehmet",
                            IsDeleted = false,
                            LastName = "Ergen"
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(2009, 1, 14, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Nevşehir",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9930),
                            Email = "yağmur.sayan.09@hotmail.com",
                            FirstName = "Yağmur",
                            IsDeleted = false,
                            LastName = "Sayan"
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(1999, 12, 10, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Mardin",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(92),
                            Email = "kaan.yurt.99@hotmail.com",
                            FirstName = "Kaan",
                            IsDeleted = false,
                            LastName = "Yurt"
                        },
                        new
                        {
                            Id = 11,
                            BirthDate = new DateTime(1985, 1, 23, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Sakarya",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(102),
                            Email = "utku.yar.85@hotmail.com",
                            FirstName = "Utku",
                            IsDeleted = false,
                            LastName = "Yar"
                        },
                        new
                        {
                            Id = 12,
                            BirthDate = new DateTime(1989, 12, 21, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "Osmaniye",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(112),
                            Email = "osman.öztürk.89@hotmail.com",
                            FirstName = "Osman",
                            IsDeleted = false,
                            LastName = "Öztürk"
                        },
                        new
                        {
                            Id = 13,
                            BirthDate = new DateTime(1978, 5, 30, 21, 0, 0, 0, DateTimeKind.Utc),
                            City = "Zonguldak",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(120),
                            Email = "kaan.derici.78@hotmail.com",
                            FirstName = "Kaan",
                            IsDeleted = false,
                            LastName = "Derici"
                        },
                        new
                        {
                            Id = 14,
                            BirthDate = new DateTime(1982, 9, 12, 21, 0, 0, 0, DateTimeKind.Utc),
                            City = "Trabzon",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(129),
                            Email = "buğra.yener.82@hotmail.com",
                            FirstName = "Buğra",
                            IsDeleted = false,
                            LastName = "Yener"
                        },
                        new
                        {
                            Id = 15,
                            BirthDate = new DateTime(2010, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc),
                            City = "İzmir",
                            CreaDate = new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(138),
                            Email = "mehmet.yıldız.10@hotmail.com",
                            FirstName = "Mehmet",
                            IsDeleted = false,
                            LastName = "Yıldız"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
