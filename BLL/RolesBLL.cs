using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP1PoyectoFinal.DAL;
using Microsoft.EntityFrameworkCore;
using AP1PoyectoFinal.Entidades;
using System.Linq.Expressions;


namespace AP1PoyectoFinal.BLL
{
    public class RolesBLL
    {
        public static bool Guardar(Roles Rol)
        {
        if (!Existe(Rol.RolId))
                return Insertar(Rol);
            else
                return Modificar(Rol);
        }

        private static bool Existe(int RolId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Roles.Any(x => x.RolId == RolId);
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

        private static bool Insertar(Roles Rol)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                if( contexto.Roles.Add(Rol) !=null)
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

        private static bool Modificar(Roles Rol)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(Rol).State = EntityState.Modified;
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

        public static Roles Buscar(int RolId)
        {
            Contexto contexto = new Contexto();
            Roles Rol;
            try
            {
                Rol = contexto.Roles.Find(RolId);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Rol;
        }

        public static bool Eliminar(int RolId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(RolId);
                if (item != null)
                {
                    contexto.Roles.Remove(item);
                    ok = contexto.SaveChanges() > 0;
                }
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

        public static List<Roles> GetList(Expression<Func<Roles, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Roles> lista = new List<Roles>();

            try
            {
                lista = contexto.Roles.Where(expression).ToList();
                contexto.Dispose();
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
