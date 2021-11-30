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
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {

            if (!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }
        private static bool Existe(int ProductoId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Productos.Any(x => x.ProductoId == ProductoId);
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

        private static bool Insertar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Productos.Add(producto);
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
        public static bool Modificar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
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

        public static bool Eliminar(int ProductoId)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Suplidores.Find(ProductoId);
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

        public static Productos Buscar(int ProductoId)
        {
            Contexto contexto = new Contexto();
            Productos producto;
            try
            {
                producto = contexto.Productos.Find(ProductoId);//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return producto;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> producto)
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Productos.Where(producto).ToList();
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

        //Metodo para disminuir del inventario cuando se realice una venta
        public static bool DisminuirInventario(int id, int cantidad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Productos producto = new Productos();
            producto = contexto.Productos.Find(id);

            if (producto != null)
            {
                try
                {
                    if (producto.Inventario > 0)
                        producto.Inventario = (producto.Inventario - cantidad);

                    contexto.Entry(producto).State = EntityState.Modified;
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
            }

            return paso;
        }

        //Metodo para Aumentar del inventario cuando se realice una venta
        public static bool AumentarInventario(int id, int cantidad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Productos producto = new Productos();
            producto = contexto.Productos.Find(id);

            if (producto != null)
            {
                try
                {
                    producto.Inventario = (producto.Inventario + cantidad);

                    contexto.Entry(producto).State = EntityState.Modified;
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
            }

            return paso;
        }
    }
}
