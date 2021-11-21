using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba_Ismarlin_Proyecto.Entidades;
using Prueba_Ismarlin_Proyecto.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Prueba_Ismarlin_Proyecto.BLL
{
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Suplidores.Add(suplidores) != null)
                    paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(suplidores).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Suplidores.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Suplidores Buscar(int id)
        {
            Suplidores suplidores = new Suplidores();
            Contexto contexto = new Contexto();
            try
            {
                suplidores = contexto.Suplidores.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return suplidores;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidores)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Suplidores.Where(suplidores).ToList();
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
