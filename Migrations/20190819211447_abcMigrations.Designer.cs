﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chefanddishes.Models;

namespace chefanddishes.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190819211447_abcMigrations")]
    partial class abcMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("chefanddishes.Models.Chef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DOB");

                    b.Property<int>("Did");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Chefs");
                });

            modelBuilder.Entity("chefanddishes.Models.Dishes", b =>
                {
                    b.Property<int>("Did")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Id");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("calories");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("nameofdish")
                        .IsRequired();

                    b.Property<int>("tastiness");

                    b.HasKey("Did");

                    b.HasIndex("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("chefanddishes.Models.Dishes", b =>
                {
                    b.HasOne("chefanddishes.Models.Chef", "myChef")
                        .WithMany("MyDish")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
