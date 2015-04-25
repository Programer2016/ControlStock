using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IRepositorio<T>
    {
        IQueryable<T> Listar();
        IQueryable<T> ObtenerPor(System.Linq.Expressions.Expression<Func<T, bool>> predicado);
        void Guardar();
        T ObtenerPorId(int Id);
        void Agregar(T entidad);
        T Modificar(T entidad, int key);
        void Eliminar(T entidad);
    }
}
