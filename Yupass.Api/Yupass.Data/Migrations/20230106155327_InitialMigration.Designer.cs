﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yupass.Data.Context;

#nullable disable

namespace Yupass.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230106155327_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Yupass.Domain.Entities.PerfisEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Permissao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Perfis", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("71f596ac-2577-43b4-8027-f10d39d715b2"),
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2200),
                            Nome = "SysAdmin",
                            Permissao = "SysAdmin",
                            Status = -1
                        },
                        new
                        {
                            Id = new Guid("1faf232e-199a-42b7-9f7f-02cab52f784b"),
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2250),
                            Nome = "Administrador",
                            Permissao = "ADM",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("37fb756f-a8e4-4263-91d3-dd92b13ccb0a"),
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2270),
                            Nome = "Gestão de Acessos",
                            Permissao = "GA",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("c3e39ced-2d36-4c81-8642-b62c3efca2ef"),
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2290),
                            Nome = "Centro de Operações de Rede",
                            Permissao = "NOC",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("127b7a47-e234-4525-92e3-33da0a913e9d"),
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2300),
                            Nome = "Supervisor",
                            Permissao = "SUP",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("5057ddcc-6656-415c-a209-48224d72be30"),
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2310),
                            Nome = "Operacional",
                            Permissao = "OPR",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Yupass.Domain.Entities.UsuariosEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AcessoTemporario")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid>("PerfilId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ebb5efb3-e879-4e2f-b61b-b857a8b40846"),
                            AcessoTemporario = false,
                            Cpf = "admin",
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2440),
                            Nome = "Administrador",
                            PerfilId = new Guid("71f596ac-2577-43b4-8027-f10d39d715b2"),
                            Senha = "4cbf07ce91e4eb057dd4ea3be83ac829141cec8253be8dc167c702c35aa3b3ac",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("9a87bd3e-ee8b-4ea7-99e2-2981de6199c0"),
                            AcessoTemporario = false,
                            Cpf = "33667879881",
                            CriadoEm = new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2450),
                            Nome = "Pedro Rodrigues",
                            PerfilId = new Guid("71f596ac-2577-43b4-8027-f10d39d715b2"),
                            Senha = "5feadddd041a836c742ccba61d11ebbc505a805552aec2cfc1225452a26683fb",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Yupass.Domain.Entities.UsuariosEntity", b =>
                {
                    b.HasOne("Yupass.Domain.Entities.PerfisEntity", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("Yupass.Domain.Entities.PerfisEntity", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}