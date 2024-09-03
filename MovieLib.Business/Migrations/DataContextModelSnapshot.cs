﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieLib.Business;

#nullable disable

namespace MovieLib.Business.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieLib.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Humor"
                        },
                        new
                        {
                            Id = 4,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("MovieLib.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Plot")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("WatchedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 2199,
                            GenreId = 2,
                            Plot = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
                            Rating = 9,
                            Seen = false,
                            Title = "The Matrix",
                            WatchedDate = new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2209,
                            GenreId = 3,
                            Plot = "78-year-old Carl Fredricksen travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
                            Rating = 7,
                            Seen = false,
                            Title = "Up",
                            WatchedDate = new DateTime(2009, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MovieLib.Domain.Movie", b =>
                {
                    b.HasOne("MovieLib.Domain.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
