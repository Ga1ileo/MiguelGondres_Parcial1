using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MiguelGondres_Parcial1.Entidades;

namespace MiguelGondres_Parcial1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = ./SlqExpress; Database = 11ArticulosDb11; Trusted_Connection = true;");
        }
    }
}
