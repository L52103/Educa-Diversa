﻿using System;
using ApiPostgre.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiPostgre.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250619014552_InitialCreate")]
    partial class InitialCreate
    {
        // <inheritdoc 
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiPostgre.Models.Categoria", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Vigencia")
                        .HasColumnType("boolean");

                    b.HasKey("Codigo");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ApiPostgre.Models.Foro", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CodigoModulo")
                        .HasColumnType("integer");

                    b.Property<int>("CodigoPersona")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoModulo");

                    b.HasIndex("CodigoPersona");

                    b.ToTable("Foros");
                });

            modelBuilder.Entity("ApiPostgre.Models.Modulo", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CodigoCategoria")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valoracion")
                        .HasColumnType("numeric");

                    b.Property<bool>("Vigencia")
                        .HasColumnType("boolean");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoCategoria");

                    b.ToTable("Modulos");
                });

            modelBuilder.Entity("ApiPostgre.Models.Multimedia", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CodigoModulo")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonaCreadora")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Vigencia")
                        .HasColumnType("boolean");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoModulo");

                    b.HasIndex("PersonaCreadora");

                    b.ToTable("Multimedia");
                });

            modelBuilder.Entity("ApiPostgre.Models.Persona", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<char>("Sexo")
                        .HasColumnType("character(1)");

                    b.Property<bool>("Vigencia")
                        .HasColumnType("boolean");

                    b.HasKey("Codigo");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ApiPostgre.Models.PersonaMultimedia", b =>
                {
                    b.Property<int>("CodigoPersona")
                        .HasColumnType("integer");

                    b.Property<int>("CodigoMultimedia")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CodigoPersona", "CodigoMultimedia");

                    b.HasIndex("CodigoMultimedia");

                    b.ToTable("PersonaMultimedia");
                });

            modelBuilder.Entity("ApiPostgre.Models.Publicacion", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CodigoForo")
                        .HasColumnType("integer");

                    b.Property<int>("CodigoPersona")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoForo");

                    b.HasIndex("CodigoPersona");

                    b.ToTable("Publicaciones");
                });

            modelBuilder.Entity("ApiPostgre.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("text");

                    b.Property<int>("CodigoPersona")
                        .HasColumnType("integer");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer");

                    b.Property<bool>("Vigencia")
                        .HasColumnType("boolean");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CodigoPersona");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiPostgre.Models.Valoracion", b =>
                {
                    b.Property<int>("CodigoValoracion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodigoValoracion"));

                    b.Property<int>("CodigoPersona")
                        .HasColumnType("integer");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CodigoValoracion");

                    b.HasIndex("CodigoPersona");

                    b.ToTable("Valoraciones");
                });

            modelBuilder.Entity("ApiPostgre.Models.Foro", b =>
                {
                    b.HasOne("ApiPostgre.Models.Modulo", "Modulo")
                        .WithMany("Foros")
                        .HasForeignKey("CodigoModulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPostgre.Models.Persona", "Persona")
                        .WithMany("Foros")
                        .HasForeignKey("CodigoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ApiPostgre.Models.Modulo", b =>
                {
                    b.HasOne("ApiPostgre.Models.Categoria", "Categoria")
                        .WithMany("Modulos")
                        .HasForeignKey("CodigoCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ApiPostgre.Models.Multimedia", b =>
                {
                    b.HasOne("ApiPostgre.Models.Modulo", "Modulo")
                        .WithMany("Multimedia")
                        .HasForeignKey("CodigoModulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPostgre.Models.Persona", "Creador")
                        .WithMany("MultimediaCreadas")
                        .HasForeignKey("PersonaCreadora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creador");

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("ApiPostgre.Models.PersonaMultimedia", b =>
                {
                    b.HasOne("ApiPostgre.Models.Multimedia", "Multimedia")
                        .WithMany("PersonasRelacionadas")
                        .HasForeignKey("CodigoMultimedia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPostgre.Models.Persona", "Persona")
                        .WithMany("MultimediaRelacionadas")
                        .HasForeignKey("CodigoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Multimedia");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ApiPostgre.Models.Publicacion", b =>
                {
                    b.HasOne("ApiPostgre.Models.Foro", "Foro")
                        .WithMany("Publicaciones")
                        .HasForeignKey("CodigoForo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPostgre.Models.Persona", "Persona")
                        .WithMany("Publicaciones")
                        .HasForeignKey("CodigoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Foro");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ApiPostgre.Models.Usuario", b =>
                {
                    b.HasOne("ApiPostgre.Models.Persona", "Persona")
                        .WithMany("Usuarios")
                        .HasForeignKey("CodigoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ApiPostgre.Models.Valoracion", b =>
                {
                    b.HasOne("ApiPostgre.Models.Persona", "Persona")
                        .WithMany("Valoraciones")
                        .HasForeignKey("CodigoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ApiPostgre.Models.Categoria", b =>
                {
                    b.Navigation("Modulos");
                });

            modelBuilder.Entity("ApiPostgre.Models.Foro", b =>
                {
                    b.Navigation("Publicaciones");
                });

            modelBuilder.Entity("ApiPostgre.Models.Modulo", b =>
                {
                    b.Navigation("Foros");

                    b.Navigation("Multimedia");
                });

            modelBuilder.Entity("ApiPostgre.Models.Multimedia", b =>
                {
                    b.Navigation("PersonasRelacionadas");
                });

            modelBuilder.Entity("ApiPostgre.Models.Persona", b =>
                {
                    b.Navigation("Foros");

                    b.Navigation("MultimediaCreadas");

                    b.Navigation("MultimediaRelacionadas");

                    b.Navigation("Publicaciones");

                    b.Navigation("Usuarios");

                    b.Navigation("Valoraciones");
                });
#pragma warning restore 612, 618
        }
    }
}
