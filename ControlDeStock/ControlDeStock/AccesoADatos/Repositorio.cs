using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        ContextoDb dbContexto;

        public Repositorio(ContextoDb dbContexto)
        {
            this.dbContexto = dbContexto;
        }

        public Repositorio()
        {
            dbContexto = new ContextoDb();
        }

        public IQueryable<T> Listar()
        {
            return dbContexto.Set<T>();
        }

        public IQueryable<T> ObtenerPor(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {

            return dbContexto.Set<T>().Where(predicado);

        }

        public T ObtenerPorId(int Id)
        {
            return dbContexto.Set<T>().Find(Id);
        }

        public void Agregar(T entidad)
        {
            dbContexto.Set<T>().Add(entidad);
            dbContexto.SaveChanges();
        }

        public T Modificar(T entidad, int key)
        {
            if (entidad == null)
                return null;

            T existing = dbContexto.Set<T>().Find(key);
            if (existing != null)
            {
                dbContexto.Entry(existing).CurrentValues.SetValues(entidad);
                dbContexto.SaveChanges();
            }
            return existing;
        }

        public void Eliminar(T entidad)
        {
            dbContexto.Set<T>().Remove(entidad);
            dbContexto.SaveChanges();
        }

        public void Guardar()
        {
            dbContexto.SaveChanges();
        }
    }
}
