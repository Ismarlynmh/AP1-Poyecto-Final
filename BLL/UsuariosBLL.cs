﻿using System;
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
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Usuarios.Add(usuarios) != null)
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

        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(usuarios).State = EntityState.Modified;
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
                var eliminar = db.Usuarios.Find(id);
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
            Contexto db = new Contexto();
            try
            {
                lista = db.Usuarios.Where(usuario).ToList();
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
