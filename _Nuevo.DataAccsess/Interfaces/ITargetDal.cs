using System.Collections.Generic;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.DataAccsess.Interfaces
{
    public interface ITargetDal : IBaseDal<Target>
    {
        List<Target> GetList(out int count, int page, string search);
        List<Target> GetListForWork();
        List<Target> GetListForHomePage();
    }
}
