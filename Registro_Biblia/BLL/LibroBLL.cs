using System;
using Registro_Biblia.Entidades;
using Registro_Biblia.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Biblia.BLL
{
    public class LibroBLL
    {
        public static bool Guardar(Libro libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Libro.Add(libro) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Libro libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(libro).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
               Libro libro = contexto.Libro.Find(id);
                contexto.Libro.Remove(libro);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Libro Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Libro libro = new Libro();

            try
            {
                libro = contexto.Libro.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return libro;
        }

        public static List<Libro> GetList(Expression<Func<Libro, bool>> expression)
        {
            List<Libro> personas = new List<Libro>();
            Contexto contexto = new Contexto();
            try
            {
                personas = contexto.Libro.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return personas;
        }
    }
}
