using System.Collections.Generic;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetList(out int count, int page, string search);
    }
}
