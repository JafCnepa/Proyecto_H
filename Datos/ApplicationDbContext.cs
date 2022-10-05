﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

 

    }
}