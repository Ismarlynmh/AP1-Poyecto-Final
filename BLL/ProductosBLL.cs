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
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Productos.Add(producto) != null)
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

        public static bool Modificar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
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
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Productos.Find(id);
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

        public static Productos Buscar(int id)
        {
            Productos producto = new Productos();
            Contexto contexto = new Contexto();
            try
            {
                producto = contexto.Productos.Find(id);
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
