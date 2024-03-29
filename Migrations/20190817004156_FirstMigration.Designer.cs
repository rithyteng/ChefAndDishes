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
    [Migration("20190817004156_FirstMigration")]
    partial class FirstMigration
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

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DOB");

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

                    b.Property<int>("calories");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<int?>("myChefId");

                    b.Property<string>("nameofdish")
                        .IsRequired();

                    b.Property<int>("tastiness");

                    b.HasKey("Did");

                    b.HasIndex("myChefId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("chefanddishes.Models.Dishes", b =>
                {
                    b.HasOne("chefanddishes.Models.Chef", "myChef")
                        .WithMany("MyDish")
                        .HasForeignKey("myChefId");
                });
#pragma warning restore 612, 618
        }
    }
}
