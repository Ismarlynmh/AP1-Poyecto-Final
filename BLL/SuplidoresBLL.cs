using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP1PoyectoFinal.Entidades;
using AP1PoyectoFinal.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AP1PoyectoFinal.BLL
{
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            if (!Existe(suplidor.SuplidorId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }
        private static bool Existe(int SuplidorId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Suplidores.Any(x => x.SuplidorId == SuplidorId);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Suplidores.Add(suplidor);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }
        public static bool Modificar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        public static bool Eliminar(int SuplidorId)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Suplidores.Find(SuplidorId);
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

        public static Suplidores Buscar(int SuplidorId)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;
            try
            {
                suplidor = contexto.Suplidores.Find(SuplidorId);//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidor;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidor)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Suplidores.Where(suplidor).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
