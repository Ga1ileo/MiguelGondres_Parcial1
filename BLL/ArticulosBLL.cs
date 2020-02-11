using Microsoft.EntityFrameworkCore;
using MiguelGondres_Parcial1.DAL;
using MiguelGondres_Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;


namespace MiguelGondres_Parcial1.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulo articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Articulos.Add(articulo) != null)
                   paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Articulo articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(articulo).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        internal static Articulo Buscar()
        {
            throw new NotImplementedException();
        }

        public static Articulo Buscar(int id)
        {
            Articulo articulo = new Articulo();
            Contexto db = new Contexto();
            try
            {
                articulo = db.Articulos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulo;
        }

    }
}
