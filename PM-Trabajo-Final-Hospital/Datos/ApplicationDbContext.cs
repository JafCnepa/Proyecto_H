using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PM_Trabajo_Final_Hospital.Models;

namespace PM_Trabajo_Final_Hospital.Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos {get; set; }
        public DbSet<Certificacion> Certificacions { get; set; }
        public DbSet<Colegiado> Colegiados { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<CitaReservas> CitaReserva { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Facturas> Factura { get; set; }
        public DbSet<Farmacias> Farmacia { get; set; }
        public DbSet<PM_Trabajo_Final_Hospital.Models.Medicamentos> Medicamentos { get; set; }
        

       

    }
}
