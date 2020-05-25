using System.Collections.Generic;
using _Nuevo.Entities.Interface;

namespace _Nuevo.Business.Interfaces
{
    public interface IBaseService<T> where T : class, ITable, new()
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetItem(int id);
        List<T> GetList();
    }
}
