﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using STO.Models.Data;

#nullable disable

namespace STO.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("STO.Models.Cars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarVin")
                        .HasColumnType("integer");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DaTofCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("STO.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DaTofCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("STO.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DaTofCreate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("STO.Models.Problems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTimeOffset>("DaTofCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("STO.Models.Services", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DaTOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<double>("Services_Cost")
                        .HasColumnType("double precision");

                    b.Property<int>("Services_TimeOfExecution")
                        .HasColumnType("integer");

                    b.Property<string>("Services_Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("STO.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DaTofCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("STO.Models.Cars", b =>
                {
                    b.HasOne("STO.Models.Client", null)
                        .WithMany("Cars")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("STO.Models.Client", b =>
                {
                    b.HasOne("STO.Models.Order", null)
                        .WithMany("Clients")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("STO.Models.Problems", b =>
                {
                    b.HasOne("STO.Models.Order", null)
                        .WithMany("Problems")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("STO.Models.Services", b =>
                {
                    b.HasOne("STO.Models.Order", null)
                        .WithMany("Services")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("STO.Models.Worker", b =>
                {
                    b.HasOne("STO.Models.Order", null)
                        .WithMany("Workers")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("STO.Models.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("STO.Models.Order", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Problems");

                    b.Navigation("Services");

                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
