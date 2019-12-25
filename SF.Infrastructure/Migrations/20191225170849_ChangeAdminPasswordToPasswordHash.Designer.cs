﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SF.Infrastructure;

namespace SF.Infrastructure.Migrations
{
    [DbContext(typeof(SFDbContext))]
    [Migration("20191225170849_ChangeAdminPasswordToPasswordHash")]
    partial class ChangeAdminPasswordToPasswordHash
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SF.Domain.Entities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(512)")
                        .HasMaxLength(512);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(512)")
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "MasterOfPuppets",
                            PasswordHash = new byte[] { 245, 118, 89, 111, 219, 76, 234, 229, 151, 177, 131, 188, 169, 101, 58, 158, 8, 4, 215, 11, 224, 167, 3, 2, 160, 202, 135, 125, 37, 212, 140, 41, 236, 32, 34, 68, 1, 51, 55, 243, 27, 100, 146, 224, 151, 67, 32, 110, 151, 97, 84, 18, 80, 9, 55, 250, 17, 45, 100, 134, 198, 0, 229, 55 },
                            PasswordSalt = new byte[] { 252, 227, 231, 127, 101, 15, 116, 42, 144, 252, 178, 132, 222, 159, 237, 250, 155, 137, 42, 17, 248, 104, 214, 124, 58, 10, 29, 191, 147, 128, 162, 131, 27, 130, 67, 61, 68, 244, 14, 186, 66, 207, 64, 120, 247, 79, 246, 117, 140, 71, 190, 200, 32, 129, 225, 158, 86, 55, 103, 81, 45, 153, 248, 52, 197, 59, 87, 148, 44, 157, 190, 25, 217, 119, 84, 123, 22, 17, 109, 227, 174, 237, 245, 200, 98, 225, 196, 89, 105, 201, 137, 228, 112, 170, 107, 120, 234, 29, 206, 83, 124, 109, 220, 159, 99, 167, 14, 87, 81, 114, 70, 133, 254, 41, 166, 138, 181, 91, 154, 122, 248, 222, 164, 36, 128, 133, 32, 10 }
                        });
                });

            modelBuilder.Entity("SF.Domain.Entities.BandEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("SF.Domain.Entities.BandGenreEntity", b =>
                {
                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("BandId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BandGenres");
                });

            modelBuilder.Entity("SF.Domain.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SF.Domain.Entities.FestivalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Festivals");
                });

            modelBuilder.Entity("SF.Domain.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SF.Domain.Entities.PartnerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("SF.Domain.Entities.PartnerFestivalEntity", b =>
                {
                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.HasKey("PartnerId", "FestivalId");

                    b.HasIndex("FestivalId");

                    b.ToTable("PartnerFestivals");
                });

            modelBuilder.Entity("SF.Domain.Entities.PerformanceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("BeginingTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.HasIndex("FestivalId");

                    b.HasIndex("StageId");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("SF.Domain.Entities.PurchaseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("BarCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TicketId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("SF.Domain.Entities.StageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("SF.Domain.Entities.TicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("BeginingTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("SF.Domain.Entities.BandGenreEntity", b =>
                {
                    b.HasOne("SF.Domain.Entities.BandEntity", "Band")
                        .WithMany("BandGenres")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SF.Domain.Entities.GenreEntity", "Genre")
                        .WithMany("BandGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SF.Domain.Entities.PartnerFestivalEntity", b =>
                {
                    b.HasOne("SF.Domain.Entities.FestivalEntity", "Festival")
                        .WithMany("PartnerFestivals")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SF.Domain.Entities.PartnerEntity", "Partner")
                        .WithMany("PartnerFestivals")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SF.Domain.Entities.PerformanceEntity", b =>
                {
                    b.HasOne("SF.Domain.Entities.BandEntity", "Band")
                        .WithMany("Performances")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SF.Domain.Entities.FestivalEntity", "Festival")
                        .WithMany("Performances")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SF.Domain.Entities.StageEntity", "Stage")
                        .WithMany("Performances")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SF.Domain.Entities.PurchaseEntity", b =>
                {
                    b.HasOne("SF.Domain.Entities.CustomerEntity", "Customer")
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SF.Domain.Entities.TicketEntity", "Ticket")
                        .WithMany("Purchases")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SF.Domain.Entities.TicketEntity", b =>
                {
                    b.HasOne("SF.Domain.Entities.FestivalEntity", "Festival")
                        .WithMany("Tickets")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
