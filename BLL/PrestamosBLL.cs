using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrimerRegistro.Dal;
using PrimerRegistro.Data;
using PrimerRegistro.Models;


namespace PrimerRegistro.BLL
{
    public class PrestamosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Prestamos.Any(e => e.PrestamoID == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;

        }

        public static bool Insertar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Prestamos.Add(prestamos) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoID))
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }

        public static bool Modificar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(prestamos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch
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
                var eliminar = db.Prestamos.Find(id);

                if (eliminar != null)
                {
                    db.Prestamos.Remove(eliminar);
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.Prestamos.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamos;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Prestamos.Where(criterio).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static decimal AumentarPrestamos(decimal Balance, decimal Monto)
        {
            Contexto contexto = new Contexto();
            decimal aux;

            try
            {
                aux = Balance + Monto;
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return aux;
        }

        public static void BalancePersona(int id, decimal aux)
        {
            Contexto contexto = new Contexto();
            Personas personas = new Personas();
            bool paso;

            try
            {
                personas = contexto.Personas.Find(id);
                personas.Balance = aux;
                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }
    }
}
