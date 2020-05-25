using System.Collections.Generic;
using _Nuevo.Entities.Interface;

namespace _Nuevo.DataAccsess.Interfaces
{
    public interface IBaseDal<T> where T : class, ITable, new()
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetItem(int id);
        List<T> GetList();
    }
}
