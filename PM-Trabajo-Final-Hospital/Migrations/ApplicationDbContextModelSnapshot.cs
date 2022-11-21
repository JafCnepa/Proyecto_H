﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PM_Trabajo_Final_Hospital.Datos;

#nullable disable

namespace PM_Trabajo_Final_Hospital.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Categoria", b =>
                {
                    b.Property<int>("IdCateogira")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCateogira"), 1L, 1);

                    b.Property<string>("Categorias")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCateogira");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Certificacion", b =>
                {
                    b.Property<int>("IdCertificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCertificacion"), 1L, 1);

                    b.Property<string>("Certificaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCertificacion");

                    b.ToTable("Certificacions");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.CitaReservas", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCita"), 1L, 1);

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int?>("MedicoIdMedico")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdCita");

                    b.HasIndex("MedicoIdMedico");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("CitaReserva");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Colegiado", b =>
                {
                    b.Property<int>("IdColegiado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColegiado"), 1L, 1);

                    b.Property<string>("Colegiados")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdColegiado");

                    b.ToTable("Colegiados");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"), 1L, 1);

                    b.Property<string>("Departamentos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDepartamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.DetalleUsuario", b =>
                {
                    b.Property<int>("DetalleUsuario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleUsuario_Id"), 1L, 1);

                    b.HasKey("DetalleUsuario_Id");

                    b.ToTable("DetalleUsuario");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Distrito", b =>
                {
                    b.Property<int>("IdDistrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDistrito"), 1L, 1);

                    b.Property<string>("Distritos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDistrito");

                    b.ToTable("Distritos");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Facturas", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"), 1L, 1);

                    b.Property<int?>("DistrtiosIdDistrito")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDistrito")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicamento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdFactura");

                    b.HasIndex("DistrtiosIdDistrito");

                    b.HasIndex("IdMedicamento");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Farmacias", b =>
                {
                    b.Property<int>("IdFarmacia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFarmacia"), 1L, 1);

                    b.Property<string>("Avenida")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("IdDistrito")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdFarmacia");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex("IdDistrito");

                    b.ToTable("Farmacia");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Medicamentos", b =>
                {
                    b.Property<int>("IdMedicamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicamento"), 1L, 1);

                    b.Property<int?>("CategoriaIdCateogira")
                        .HasColumnType("int");

                    b.Property<int?>("FarmaciaIdFarmacia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdFarmacia")
                        .HasColumnType("int");

                    b.Property<int>("IdStocks")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Precio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StockIdStock")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdMedicamento");

                    b.HasIndex("CategoriaIdCateogira");

                    b.HasIndex("FarmaciaIdFarmacia");

                    b.HasIndex("StockIdStock");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedico"), 1L, 1);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("CertificacionIdCertificacion")
                        .HasColumnType("int");

                    b.Property<int?>("ColegiadoIdColegiado")
                        .HasColumnType("int");

                    b.Property<string>("Dnimedico")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCertificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdColegiado")
                        .HasColumnType("int");

                    b.Property<string>("Nombrecompletomedico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Salon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdMedico");

                    b.HasIndex("CertificacionIdCertificacion");

                    b.HasIndex("ColegiadoIdColegiado");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Stocks", b =>
                {
                    b.Property<int>("IdStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStock"), 1L, 1);

                    b.Property<string>("StockName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStock");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Usuario", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Celularusuario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("DetalleUsuario_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Detalle_Usuario")
                        .HasColumnType("int");

                    b.Property<string>("Dniusuario")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<bool>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombrecompletousuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rucusuario")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Usuario1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasIndex("Detalle_Usuario")
                        .IsUnique()
                        .HasFilter("[Detalle_Usuario] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.CitaReservas", b =>
                {
                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoIdMedico");

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1");

                    b.Navigation("Medico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Facturas", b =>
                {
                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Distrito", "Distrtios")
                        .WithMany()
                        .HasForeignKey("DistrtiosIdDistrito");

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Medicamentos", "Medicamento")
                        .WithMany()
                        .HasForeignKey("IdMedicamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1");

                    b.Navigation("Distrtios");

                    b.Navigation("Medicamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Farmacias", b =>
                {
                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Distrito", "Distrito")
                        .WithMany()
                        .HasForeignKey("IdDistrito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Distrito");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Medicamentos", b =>
                {
                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaIdCateogira");

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Farmacias", "Farmacia")
                        .WithMany()
                        .HasForeignKey("FarmaciaIdFarmacia");

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Stocks", "Stock")
                        .WithMany()
                        .HasForeignKey("StockIdStock");

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1");

                    b.Navigation("Categoria");

                    b.Navigation("Farmacia");

                    b.Navigation("Stock");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Medico", b =>
                {
                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Certificacion", "Certificacion")
                        .WithMany()
                        .HasForeignKey("CertificacionIdCertificacion");

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Colegiado", "Colegiado")
                        .WithMany()
                        .HasForeignKey("ColegiadoIdColegiado");

                    b.HasOne("PM_Trabajo_Final_Hospital.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1");

                    b.Navigation("Certificacion");

                    b.Navigation("Colegiado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.Usuario", b =>
                {
                    b.HasOne("PM_Trabajo_Final_Hospital.Models.DetalleUsuario", "DetalleUsuario")
                        .WithOne("Usuario")
                        .HasForeignKey("PM_Trabajo_Final_Hospital.Models.Usuario", "Detalle_Usuario");

                    b.Navigation("DetalleUsuario");
                });

            modelBuilder.Entity("PM_Trabajo_Final_Hospital.Models.DetalleUsuario", b =>
                {
                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
