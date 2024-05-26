﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodeStructure.Controllers;

#nullable disable

namespace NodeStructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("NodeStructure.Models.NodesInfo", b =>
                {
                    b.Property<int>("nodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nodeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("parentNodeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("startDate")
                        .HasColumnType("TEXT");

                    b.HasKey("nodeId");

                    b.ToTable("nodesInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
