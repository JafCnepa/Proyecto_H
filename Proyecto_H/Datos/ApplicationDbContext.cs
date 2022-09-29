using Microsoft.EntityFrameworkCore;
using Proyecto_H.Models;

namespace Proyecto_H.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
        //Importando Los Modelos
        public DbSet<Medico> Medico { get; set; }
            public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Factura> Factura { get; set; } 
        public DbSet<Reserva> Reserva { get; set; } 
            
       
    }
}
