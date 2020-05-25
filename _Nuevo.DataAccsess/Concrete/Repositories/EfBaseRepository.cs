using System.Collections.Generic;
using System.Linq;
using _Nuevo.DataAccsess.Concrete.EntityFrameworkCore.Context;
using _Nuevo.DataAccsess.Interfaces;
using _Nuevo.Entities.Interface;

namespace _Nuevo.DataAccsess.Concrete.Repositories
{
    public class EfBaseRepository<T> : IBaseDal<T> where T : class, ITable, new()
    {
        public void Add(T obj)
        {
            using var context = new NuevoContext();
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }
        public void Delete(T obj)
        {
            using var context = new NuevoContext();
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }
        public T GetItem(int id)
        {
            using var context = new NuevoContext();
            return context.Set<T>().Find(id);
        }
        public List<T> GetList()
        {
            using var context = new NuevoContext();
            return context.Set<T>().ToList();
        }
        public void Update(T obj)
        {
            using var context = new NuevoContext();
            context.Set<T>().Update(obj);
            context.SaveChanges();
        }
    }
}
