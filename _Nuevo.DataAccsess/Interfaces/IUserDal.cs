using System.Collections.Generic;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.DataAccsess.Interfaces
{
    public interface IUserDal
    {
        List<AppUser> GetList(out int count, int page, string search);
    }
}
