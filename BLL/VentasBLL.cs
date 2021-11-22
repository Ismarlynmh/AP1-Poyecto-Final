using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Prueba_Ismarlin_Proyecto.Entidades;
using Prueba_Ismarlin_Proyecto.DAL;

namespace Prueba_Ismarlin_Proyecto.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas venta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Ventas.Add(venta) != null)
                    paso = (db.SaveChanges() > 0);
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

        public static bool Modificar(Ventas venta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM VentasDetalles where VentaId = {venta.VentaId}");
                foreach (var item in venta.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(venta).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

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
                var eliminar = db.Ventas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
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

        public static Ventas Buscar(int id)
        {
            Ventas venta = new Ventas();
            Contexto db = new Contexto();

            try
            {
                venta = db.Ventas.Where(x => x.VentaId == id).
                     Include(y => y.Detalle).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return venta;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> venta)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Ventas.Where(venta).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
