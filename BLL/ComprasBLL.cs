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
    public class ComprasBLL
    {
        public static bool Guardar(Compras compra)
        {
            if (!Existe(compra.CompraId))
                return Insertar(compra);
            else
                return Modificar(compra);
        }
        private static bool Existe(int CompraId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Compras.Any(x => x.CompraId == CompraId);
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

        private static bool Insertar(Compras compra)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                foreach (var item in compra.Detalle)
                {
                    contexto.Entry(item.ProductoId).State = EntityState.Modified;
                }
                contexto.Compras.Add(compra);
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
        public static bool Modificar(Compras compra)
        {
            bool ok = false;
            Contexto contexto = new Contexto();
            try
            {

                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalle where CompraId = {compra.CompraId}");
                foreach (var item in compra.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(compra).State = EntityState.Modified;
                ok = (contexto.SaveChanges() > 0);

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

        public static bool Eliminar(int CompraId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(CompraId);
                if (item != null)
                {
                    contexto.Compras.Remove(item);
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

        public static Compras Buscar(int CompraId)
        {
            Contexto contexto = new Contexto();
            Compras compra;
            try
            {
                compra = contexto.Compras
                    .Where(x => x.CompraId == CompraId)
                    .Include(d => d.Detalle)
                    .ThenInclude(d => d.ProductoId)
                    .SingleOrDefault();//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return compra;
        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> compra)
        {
            List<Compras> lista = new List<Compras>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Compras.Where(compra).Include(X => X.Detalle).ThenInclude(d => d.ProductoId).ToList();
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
