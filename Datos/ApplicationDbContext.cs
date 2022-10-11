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
        //Improtando  los model
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Farmacia> Farmacias { get; set; }

 

    }
}
