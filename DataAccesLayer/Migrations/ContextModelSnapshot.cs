﻿// <auto-generated />
using System;
using DataAccesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"), 1L, 1);

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int?>("BuildingId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StorehouseId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("WorkOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RoomId");

                    b.HasIndex("StorehouseId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StorehouseId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("StorehouseId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int?>("BuildingId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Storehouse", b =>
                {
                    b.Property<int>("StorehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StorehouseId"), 1L, 1);

                    b.Property<int?>("BuildingId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("StorehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StorehouseId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Storehouses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Order", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Building", "Building")
                        .WithMany("Orders")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Room", "Room")
                        .WithMany("Orders")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Storehouse", "Storehouse")
                        .WithMany("Orders")
                        .HasForeignKey("StorehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Product");

                    b.Navigation("Room");

                    b.Navigation("Storehouse");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Storehouse", "Storehouse")
                        .WithMany("Products")
                        .HasForeignKey("StorehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storehouse");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Room", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Building", "Building")
                        .WithMany("Rooms")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Storehouse", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Building", "Building")
                        .WithMany("Storehouses")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Building", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Rooms");

                    b.Navigation("Storehouses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Room", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Storehouse", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
