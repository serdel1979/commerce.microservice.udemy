﻿// <auto-generated />
using System;
using Comercio.Autores.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Comercio.Autores.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240823132739_ninit")]
    partial class ninit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Comercio.Autores.Modelo.AutorLibro", b =>
                {
                    b.Property<int>("AutorLibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AutorLibroId"));

                    b.Property<string>("Apellido")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("AutorLibroId");

                    b.ToTable("AutoresLibros");
                });

            modelBuilder.Entity("Comercio.Autores.Modelo.GradoAcademico", b =>
                {
                    b.Property<int>("GradoAcademicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GradoAcademicoId"));

                    b.Property<int>("AutorLibroId")
                        .HasColumnType("integer");

                    b.Property<string>("CentroAcademico")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaGrado")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GradoAcademicoGuid")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("GradoAcademicoId");

                    b.HasIndex("AutorLibroId");

                    b.ToTable("GradoAcademicos");
                });

            modelBuilder.Entity("Comercio.Autores.Modelo.GradoAcademico", b =>
                {
                    b.HasOne("Comercio.Autores.Modelo.AutorLibro", "AutorLibro")
                        .WithMany("ListaGradoAcademico")
                        .HasForeignKey("AutorLibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutorLibro");
                });

            modelBuilder.Entity("Comercio.Autores.Modelo.AutorLibro", b =>
                {
                    b.Navigation("ListaGradoAcademico");
                });
#pragma warning restore 612, 618
        }
    }
}
