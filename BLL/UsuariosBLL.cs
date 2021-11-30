using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AP1PoyectoFinal.DAL;
using AP1PoyectoFinal.Entidades;
using System.Security.Cryptography;


namespace AP1PoyectoFinal.BLL
{
   public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            if (!Existe(usuarios.UsuariosId))
                return Insertar(usuarios);
            else
                return Modificar(usuarios);
        }
        private static bool Existe(int UsuariosId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Usuarios.Any(x => x.UsuariosId == UsuariosId);
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
        private static bool Insertar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Usuarios.Add(usuarios);
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

        public static bool Modificar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(usuarios).State = EntityState.Modified;
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

        public static bool Eliminar(int UsuariosId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(UsuariosId);
                if (item != null)
                {
                    contexto.Usuarios.Remove(item);
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

        public static Usuarios Buscar(int id)
        {
            Usuarios usuario = new Usuarios();
            Contexto db = new Contexto();
            try
            {
                usuario = db.Usuarios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuario;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Usuarios.Where(usuario).ToList();
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
