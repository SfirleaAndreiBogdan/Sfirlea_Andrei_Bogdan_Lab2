﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sfirlea_Andrei_Bogdan_Lab2.Data;

#nullable disable

namespace Sfirlea_Andrei_Bogdan_Lab2.Migrations
{
    [DbContext(typeof(Sfirlea_Andrei_Bogdan_Lab2Context))]
    partial class Sfirlea_Andrei_Bogdan_Lab2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sfirlea_Andrei_Bogdan_Lab2.Models.Authors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Sfirlea_Andrei_Bogdan_Lab2.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int?>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6 ,2)");

                    b.Property<int?>("PublisherID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorsId");

                    b.HasIndex("PublisherID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Sfirlea_Andrei_Bogdan_Lab2.Models.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("Sfirlea_Andrei_Bogdan_Lab2.Models.Book", b =>
                {
                    b.HasOne("Sfirlea_Andrei_Bogdan_Lab2.Models.Authors", "Authors")
                        .WithMany("Books")
                        .HasForeignKey("AuthorsId");

                    b.HasOne("Sfirlea_Andrei_Bogdan_Lab2.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherID");

                    b.Navigation("Authors");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Sfirlea_Andrei_Bogdan_Lab2.Models.Authors", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Sfirlea_Andrei_Bogdan_Lab2.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}