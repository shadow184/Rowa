﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rowa.repository;

namespace rowa.repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("rowa.repository.Entities.ErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsInner");

                    b.Property<DateTime>("LogDate");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<int>("ParentId");

                    b.Property<string>("Server");

                    b.Property<string>("StackTrace")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ErrorLog");
                });

            modelBuilder.Entity("rowa.repository.Entities.PageVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IpAddress");

                    b.Property<DateTime>("LastVisitedDate");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.Property<int>("VisitCount");

                    b.HasKey("Id");

                    b.ToTable("PageVisit");
                });

            modelBuilder.Entity("rowa.repository.Entities.PerformanceLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<double>("ExecutionTime");

                    b.Property<string>("IpAddress");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime?>("RequestDate");

                    b.Property<string>("ServerName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("PerformanceLog");
                });

            modelBuilder.Entity("rowa.repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int?>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("rowa.repository.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Role")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("rowa.repository.Entities.User", b =>
                {
                    b.HasOne("rowa.repository.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
