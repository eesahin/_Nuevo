using System.Collections.Generic;
using _Nuevo.Business.Interfaces;
using _Nuevo.DataAccsess.Interfaces;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.Business.Concrete
{
   public class AppUserManager : IAppUserService
   {
       private readonly IUserDal _userDal;
       public AppUserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }
       public List<AppUser> GetList(out int count, int page, string search)
       {
           return _userDal.GetList(out count, page, search);
       }
   }
}
