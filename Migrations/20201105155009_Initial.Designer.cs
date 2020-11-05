﻿// <auto-generated />
using System;
using BackendAssignmentPt2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendAssignmentPt2.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20201105155009_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendAssignmentPt2.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BackendAssignmentPt2.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFileName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("BackendAssignmentPt2.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Composer")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("TIME");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("TrackId");

                    b.HasIndex("ProductId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("BackendAssignmentPt2.Models.Book", b =>
                {
                    b.HasBaseType("BackendAssignmentPt2.Models.Product");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<short>("Published")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("BackendAssignmentPt2.Models.Movie", b =>
                {
                    b.HasBaseType("BackendAssignmentPt2.Models.Product");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<short>("MovieReleased")
                        .HasColumnType("SMALLINT");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("BackendAssignmentPt2.Models.MusicCD", b =>
                {
                    b.HasBaseType("BackendAssignmentPt2.Models.Product");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<short>("CDReleased")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasDiscriminator().HasValue("MusicCD");
                });

            modelBuilder.Entity("BackendAssignmentPt2.Models.Product", b =>
                {
                    b.HasOne("BackendAssignmentPt2.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackendAssignmentPt2.Models.Track", b =>
                {
                    b.HasOne("BackendAssignmentPt2.Models.Product", "Product")
                        .WithMany("Tracks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
