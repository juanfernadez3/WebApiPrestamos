using Microsoft.EntityFrameworkCore;
using PrimerRegistro.Dal;
using PrimerRegistro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerRegistro.BLL
{
    public class MorasBLL
    {
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Moras.Any(x => x.MoraId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
        public static bool Guardar(Moras mora)
        {
            if (!Existe(mora.MoraId))
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        public static bool Insertar(Moras mora)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Moras.Add(mora);
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

        public static bool Modificar(Moras mora)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle where MoraId = {mora.MoraId}");

                foreach (var item in mora.MorasDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(mora).State = EntityState.Modified;
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
                var mora = db.Moras.Find(id);

                if (mora != null)
                {
                    db.Moras.Remove(mora);
                    paso = db.SaveChanges() > 0;
                }
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

        public static Moras Buscar(int id)
        {
            Contexto db = new Contexto();
            Moras mora = new Moras();

            try
            {
                mora = db.Moras
                    .Where(e => e.MoraId == id)
                    .Include(e => e.MorasDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return mora;
        }

        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> lista = new List<Moras>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Moras.Where(criterio).ToList();
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
