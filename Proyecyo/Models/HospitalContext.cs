using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Proyecyo.Models;

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
                    .HasName("PK__Facturas__6C08ED53FAF68430");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .HasColumnName("dni");

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

                entity.Property(e => e.Ruc)
                    .HasMaxLength(15)
                    .HasColumnName("ruc");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoPago)
                    .HasMaxLength(100)
                    .HasColumnName("tipo_pago");

                entity.Property(e => e.Total)
                    .HasMaxLength(1000)
                    .HasColumnName("total");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Facturas__id_med__412EB0B6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Facturas__id_usu__403A8C7D");
            });

            modelBuilder.Entity<Farmacia>(entity =>
            {
                entity.HasKey(e => e.IdFarmacia)
                    .HasName("PK__Farmacia__89B9BF9EA1A52C17");

                entity.Property(e => e.IdFarmacia).HasColumnName("id_farmacia");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(30)
                    .HasColumnName("departamento");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(30)
                    .HasColumnName("distrito");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pais)
                    .HasMaxLength(30)
                    .HasColumnName("pais");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                    .HasName("PK__Medicame__2588C032D6DDE72B");

                entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .HasColumnName("categoria");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdFarmacia).HasColumnName("id_farmacia");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

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
                    .HasConstraintName("FK__Medicamen__id_fa__398D8EEE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicamen__id_fa__38996AB5");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medicos__E038EB4377B2E58A");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .HasColumnName("apellido");

                entity.Property(e => e.Certificado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("certificado");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .HasColumnName("dni");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(20)
                    .HasColumnName("especialidad");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicos__id_usua__286302EC");
            });

            modelBuilder.Entity<ReservaCitum>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Reserva___6AEC3C09BE22ECAB");

                entity.ToTable("Reserva_Cita");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.ReservaCita)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva_C__id_me__47DBAE45");
            });

            modelBuilder.Entity<ReservaMedicamento>(entity =>
            {
                entity.HasKey(e => e.IdReservamedicamento)
                    .HasName("PK__Reserva___3BBD2AFC9BB1E319");

                entity.ToTable("Reserva_Medicamento");

                entity.Property(e => e.IdReservamedicamento).HasColumnName("id_reservamedicamento");

                entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.ReservaMedicamentos)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva_M__id_me__4AB81AF0");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__4E3E04AD370954BB");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .HasColumnName("apellido");

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .HasColumnName("celular");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .HasColumnName("dni");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(15)
                    .HasColumnName("ruc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    }
}
