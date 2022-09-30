using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
namespace Proyecto.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
        //Importando Los Modelos
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Reservas> Reservas { get; set; }


    }
}
