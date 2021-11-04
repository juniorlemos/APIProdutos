﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modelo.Infra.Data.Context;

namespace Modelo.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211105021019_APIProd2")]
    partial class APIProd2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Modelo.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Nome");

                    b.ToTable("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
