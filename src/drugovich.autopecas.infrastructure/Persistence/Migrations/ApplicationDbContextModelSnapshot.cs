﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using drugovich.autopecas.infrastructure.Persistence;

#nullable disable

namespace drugovich.autopecas.infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("drugovich.autopecas.core.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataFundacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("CLIENTES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CNPJ = "49341109000181",
                            DataFundacao = new DateTime(2022, 10, 9, 22, 10, 17, 379, DateTimeKind.Local).AddTicks(9578),
                            GrupoId = 1,
                            Nome = "Cliente1"
                        },
                        new
                        {
                            Id = 2,
                            CNPJ = "49341109000181",
                            DataFundacao = new DateTime(2022, 10, 9, 22, 10, 17, 379, DateTimeKind.Local).AddTicks(9595),
                            GrupoId = 2,
                            Nome = "Cliente2"
                        });
                });

            modelBuilder.Entity("drugovich.autopecas.core.Gerente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GERENTES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "gerente1@email.com",
                            Nivel = 1,
                            Nome = "gerente1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "gerente2@email.com",
                            Nivel = 2,
                            Nome = "gerente2"
                        });
                });

            modelBuilder.Entity("drugovich.autopecas.core.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GRUPOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Grupo A"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Grupo B"
                        });
                });

            modelBuilder.Entity("drugovich.autopecas.core.Cliente", b =>
                {
                    b.HasOne("drugovich.autopecas.core.Grupo", "Grupo")
                        .WithMany("Clientes")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("drugovich.autopecas.core.Grupo", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
