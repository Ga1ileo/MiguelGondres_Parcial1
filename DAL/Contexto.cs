using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MiguelGondres_Parcial1.Entidades;

namespace MiguelGondres_Parcial1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> articulo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"./SqlExpress ; Database = TestDb; Trusted_Connection = True; ");
        }
    }
}
