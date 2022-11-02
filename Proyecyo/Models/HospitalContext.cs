﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecyo.Models
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Farmacia> Farmacias { get; set; }
        public virtual DbSet<Medicamento> Medicamentos { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<ReservaCitum> ReservaCita { get; set; }
        public virtual DbSet<ReservaMedicamento> ReservaMedicamentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Hospital;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Facturas__6C08ED53E3047DA2");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Total)
                    .HasMaxLength(1000)
                    .HasColumnName("total");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Facturas__id_med__32E0915F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Facturas__id_usu__31EC6D26");
            });

            modelBuilder.Entity<Farmacia>(entity =>
            {
                entity.HasKey(e => e.IdFarmacia)
                    .HasName("PK__Farmacia__89B9BF9ECCFA0BDD");

                entity.Property(e => e.IdFarmacia).HasColumnName("id_farmacia");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(30)
                    .HasColumnName("departamento");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(30)
                    .HasColumnName("distrito");

                entity.Property(e => e.Nombrefarmacia)
                    .HasMaxLength(100)
                    .HasColumnName("nombrefarmacia");

                entity.Property(e => e.Pais)
                    .HasMaxLength(30)
                    .HasColumnName("pais");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                    .HasName("PK__Medicame__2588C032DBAD76D8");

                entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .HasColumnName("categoria");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdFarmacia).HasColumnName("id_farmacia");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombremedicamento)
                    .HasMaxLength(100)
                    .HasColumnName("nombremedicamento");

                entity.Property(e => e.Precio)
                    .HasMaxLength(1000)
                    .HasColumnName("precio");

                entity.Property(e => e.Stock)
                    .HasMaxLength(100)
                    .HasColumnName("stock");

                entity.HasOne(d => d.IdFarmaciaNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdFarmacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicamen__id_fa__2F10007B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicamen__id_fa__2E1BDC42");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medicos__E038EB43B2153EA9");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.Certificado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("certificado");

                entity.Property(e => e.Dnidoctor)
                    .HasMaxLength(8)
                    .HasColumnName("dnidoctor");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("especialidad");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombrecompletodoctor)
                    .HasMaxLength(20)
                    .HasColumnName("nombrecompletodoctor");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .HasColumnName("ubicacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicos__id_usua__29572725");
            });

            modelBuilder.Entity<ReservaCitum>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Reserva___6AEC3C09920A49DD");

                entity.ToTable("Reserva_Cita");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.FechaReserva)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_reserva");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.ReservaCita)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva_C__id_me__36B12243");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ReservaCita)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva_C__id_us__37A5467C");
            });

            modelBuilder.Entity<ReservaMedicamento>(entity =>
            {
                entity.HasKey(e => e.IdReservamedicamento)
                    .HasName("PK__Reserva___3BBD2AFCC3732A50");

                entity.ToTable("Reserva_Medicamento");

                entity.Property(e => e.IdReservamedicamento).HasColumnName("id_reservamedicamento");

                entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");

                entity.Property(e => e.Stock)
                    .HasMaxLength(30)
                    .HasColumnName("stock");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.ReservaMedicamentos)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva_M__id_me__3D5E1FD2");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__4E3E04ADC23B0039");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Celularusuario)
                    .HasMaxLength(20)
                    .HasColumnName("celularusuario");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .HasColumnName("clave");

                entity.Property(e => e.Correousuario)
                    .HasMaxLength(50)
                    .HasColumnName("correousuario");

                entity.Property(e => e.Dniusuario)
                    .HasMaxLength(8)
                    .HasColumnName("dniusuario");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombrecompletousuario)
                    .HasMaxLength(50)
                    .HasColumnName("nombrecompletousuario");

                entity.Property(e => e.Rucusuario)
                    .HasMaxLength(15)
                    .HasColumnName("rucusuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
