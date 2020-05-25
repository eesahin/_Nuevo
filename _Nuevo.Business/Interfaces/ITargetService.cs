using System.Collections.Generic;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.Business.Interfaces
{
    public interface ITargetService : IBaseService<Target>
    {
        List<Target> GetList(out int count, int page, string search);
        List<Target> GetListForWork();
        List<Target> GetListForHomePage();
    }
}
