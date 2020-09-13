﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tiangong.Repository;

namespace tiangong.Migrations
{
    [DbContext(typeof(TGContext))]
    [Migration("20200913110104_add_col_telphone")]
    partial class add_col_telphone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("tiangong.Models.Hotel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("createby")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("createtime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("lastupdateby")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("lastupdatetime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("star")
                        .HasColumnType("int");

                    b.Property<string>("telephone")
                        .HasColumnType("varchar(11) CHARACTER SET utf8mb4")
                        .HasMaxLength(11);

                    b.HasKey("id");

                    b.ToTable("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
