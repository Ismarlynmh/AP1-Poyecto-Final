using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AP1PoyectoFinal.Entidades;
using AP1PoyectoFinal.DAL;

namespace AP1PoyectoFinal.BLL
{
    public class EmpleadosBLL
    {
        public static bool Guardar(Empleados empleado)
        {
            if (!Existe(empleado.EmpleadoId))
                return Insertar(empleado);
            else
                return Modificar(empleado);
        }
        private static bool Existe(int EmpleadoId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Empleados.Any(x => x.EmpleadoId == EmpleadoId);
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

        private static bool Insertar(Empleados empleado)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Empleados.Add(empleado);
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

        public static bool Modificar(Empleados empleado)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(empleado).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Empleados.Find(id);
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

        public static Empleados Buscar(int EmpleadoId)
        {
            Contexto contexto = new Contexto();
            Empleados empleado;
            try
            {
                empleado = contexto.Empleados.Find(EmpleadoId);//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return empleado;
        }

        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> empleado)
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Empleados.Where(empleado).ToList();
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
