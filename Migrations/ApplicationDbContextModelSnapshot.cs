﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto.Datos;

#nullable disable

namespace Proyecto.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proyecto.Models.Factura", b =>
                {
                    b.Property<int>("id_factura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_factura"), 1L, 1);

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("precio")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("stock")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("id_factura");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Proyecto.Models.Medico", b =>
                {
                    b.Property<int>("id_medico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_medico"), 1L, 1);

                    b.Property<int?>("Reservasid_reserva")
                        .HasColumnType("int");

                    b.Property<int?>("Usuariosid_usuario")
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_medico");

                    b.HasIndex("Reservasid_reserva");

                    b.HasIndex("Usuariosid_usuario");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Proyecto.Models.Productos", b =>
                {
                    b.Property<int>("id_productos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_productos"), 1L, 1);

                    b.Property<int?>("Reservasid_reserva")
                        .HasColumnType("int");

                    b.Property<string>("categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("precio")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("stock")
                        .HasColumnType("int");

                    b.HasKey("id_productos");

                    b.HasIndex("Reservasid_reserva");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Proyecto.Models.Reservas", b =>
                {
                    b.Property<int>("id_reserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_reserva"), 1L, 1);

                    b.Property<int>("id_medico")
                        .HasColumnType("int");

                    b.Property<int>("id_productos")
                        .HasColumnType("int");

                    b.HasKey("id_reserva");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Proyecto.Models.Usuarios", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_usuario"), 1L, 1);

                    b.Property<int?>("Facturaid_factura")
                        .HasColumnType("int");

                    b.Property<int?>("Productosid_productos")
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime?>("fecha_nacimiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ruc")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("id_usuario");

                    b.HasIndex("Facturaid_factura");

                    b.HasIndex("Productosid_productos");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Proyecto.Models.Medico", b =>
                {
                    b.HasOne("Proyecto.Models.Reservas", null)
                        .WithMany("Medico")
                        .HasForeignKey("Reservasid_reserva");

                    b.HasOne("Proyecto.Models.Usuarios", null)
                        .WithMany("Medico")
                        .HasForeignKey("Usuariosid_usuario");
                });

            modelBuilder.Entity("Proyecto.Models.Productos", b =>
                {
                    b.HasOne("Proyecto.Models.Reservas", null)
                        .WithMany("Productos")
                        .HasForeignKey("Reservasid_reserva");
                });

            modelBuilder.Entity("Proyecto.Models.Usuarios", b =>
                {
                    b.HasOne("Proyecto.Models.Factura", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("Facturaid_factura");

                    b.HasOne("Proyecto.Models.Productos", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("Productosid_productos");
                });

            modelBuilder.Entity("Proyecto.Models.Factura", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Proyecto.Models.Productos", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Proyecto.Models.Reservas", b =>
                {
                    b.Navigation("Medico");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Proyecto.Models.Usuarios", b =>
                {
                    b.Navigation("Medico");
                });
#pragma warning restore 612, 618
        }
    }
}
