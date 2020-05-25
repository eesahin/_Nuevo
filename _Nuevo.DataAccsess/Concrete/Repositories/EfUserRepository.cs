using System;
using System.Collections.Generic;
using System.Linq;
using _Nuevo.DataAccsess.Concrete.EntityFrameworkCore.Context;
using _Nuevo.DataAccsess.Interfaces;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.DataAccsess.Concrete.Repositories
{
    public class EfUserRepository : IUserDal
    {
        public List<AppUser> GetList(out int count, int page, string search)
        {
            using var context = new NuevoContext();
            var result = context.Users.AsQueryable();
            count = (int)Math.Ceiling((double)result.Count() / 7);
            if (!string.IsNullOrWhiteSpace(search))
            {
                result = result.Where(u => u.Name.Trim().ToLower().Contains(search.Trim().ToLower())
                                           || u.Surname.Trim().ToLower().Contains(search.Trim().ToLower())
                                           || u.Email.Trim().ToLower().Contains(search.Trim().ToLower())
                                           || u.UserName.Trim().ToLower().Contains(search.Trim().ToLower()));
                count = (int)Math.Ceiling((double)result.Count() / 7);
            }
            result = result.Skip((page - 1) * 7).Take(7);
            return result.ToList();
        }
    }
}
