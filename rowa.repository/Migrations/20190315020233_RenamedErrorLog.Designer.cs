﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rowa.repository;

namespace rowa.repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190315020233_RenamedErrorLog")]
    partial class RenamedErrorLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

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
#pragma warning restore 612, 618
        }
    }
}
