﻿using System;
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
    public class EmpleadosBLL
    {
        public static bool Guardar(Empleados empleados)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Empleados.Add(empleados) != null)
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

        public static bool Modificar(Empleados empleados)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(empleados).State = EntityState.Modified;
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

        public static Empleados Buscar(int id)
        {
            Empleados empleados = new Empleados();
            Contexto db = new Contexto();
            try
            {
                empleados = db.Empleados.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return empleados;
        }

        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> empleados)
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Empleados.Where(empleados).ToList();
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
