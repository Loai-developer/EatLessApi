﻿// <auto-generated />
using System;
using System.Collections.Generic;
using EatLess.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EatLess.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241214005239_addFoodItemsSeedDate")]
    partial class addFoodItemsSeedDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EatLess.Domain.Entities.FoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CaloriesPerOneGram")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FoodTypeEnum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FoodType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("foodItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2170c0d5-66c2-4e7f-9403-d988f13a3032"),
                            CaloriesPerOneGram = 140m,
                            FoodTypeEnum = "Carb",
                            Name = "Rice",
                            Photo = ""
                        },
                        new
                        {
                            Id = new Guid("a8b70c16-5f47-4dce-b8fa-8ef2bb506a1b"),
                            CaloriesPerOneGram = 165m,
                            FoodTypeEnum = "Protein",
                            Name = "ChickenBreasts",
                            Photo = ""
                        },
                        new
                        {
                            Id = new Guid("0877f26a-00ca-499d-b125-0585b5bcca4b"),
                            CaloriesPerOneGram = 25m,
                            FoodTypeEnum = "Fiber",
                            Name = "Salad",
                            Photo = ""
                        },
                        new
                        {
                            Id = new Guid("191eae96-0ab1-4ea0-8c15-359a437c2d74"),
                            CaloriesPerOneGram = 180m,
                            FoodTypeEnum = "Protein",
                            Name = "ChickenSighs",
                            Photo = ""
                        });
                });

            modelBuilder.Entity("EatLess.Domain.Entities.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MealTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ComplexProperty<Dictionary<string, object>>("MealName", "EatLess.Domain.Entities.Meal.MealName#MealName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");
                        });

                    b.HasKey("Id");

                    b.ToTable("meals");
                });

            modelBuilder.Entity("EatLess.Domain.Entities.MealComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("MealId");

                    b.ToTable("mealComponents");
                });

            modelBuilder.Entity("EatLess.Domain.Entities.MealComponent", b =>
                {
                    b.HasOne("EatLess.Domain.Entities.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EatLess.Domain.Entities.Meal", "Meal")
                        .WithMany("MealComponents")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("EatLess.Domain.Entities.Meal", b =>
                {
                    b.Navigation("MealComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
