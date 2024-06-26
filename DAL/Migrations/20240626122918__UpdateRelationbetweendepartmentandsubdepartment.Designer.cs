﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pioneers.DAL.Context;

#nullable disable

namespace Pioneers.DAL.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20240626122918__UpdateRelationbetweendepartmentandsubdepartment")]
    partial class _UpdateRelationbetweendepartmentandsubdepartment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pioneers.DAL.Entities.ChildDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShownUser")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("ChildDepartments");
                });

            modelBuilder.Entity("Pioneers.DAL.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ChildDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShownUser")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("ChildDepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Pioneers.DAL.Entities.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Pioneers.DAL.Entities.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("Pioneers.DAL.Entities.Department", b =>
                {
                    b.HasOne("Pioneers.DAL.Entities.ChildDepartment", "ChildDepartment")
                        .WithMany("Departments")
                        .HasForeignKey("ChildDepartmentId");

                    b.Navigation("ChildDepartment");
                });

            modelBuilder.Entity("Pioneers.DAL.Entities.ChildDepartment", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
