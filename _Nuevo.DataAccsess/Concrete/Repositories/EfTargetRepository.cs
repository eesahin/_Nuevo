using System;
using System.Collections.Generic;
using System.Linq;
using _Nuevo.DataAccsess.Concrete.EntityFrameworkCore.Context;
using _Nuevo.DataAccsess.Interfaces;
using _Nuevo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace _Nuevo.DataAccsess.Concrete.Repositories
{
    public class EfTargetRepository : EfBaseRepository<Target>, ITargetDal
    {
        public List<Target> GetList(out int count, int page, string search)
        {
            using var context = new NuevoContext();
            var result = context.Targets.AsQueryable();
            count = (int)Math.Ceiling((double)result.Count() / 7);
            if (!string.IsNullOrWhiteSpace(search))
            {
                result = result.Where(u => u.Url.Trim().ToLower().Contains(search.Trim().ToLower())
                || u.Name.Trim().ToLower().Contains(search.Trim().ToLower()));
                count = (int)Math.Ceiling((double)result.Count() / 7);
            }
            result = result.Skip((page - 1) * 7).Take(7);
            result = result.Include(u => u.Status).Include(u => u.User);
            return result.ToList();
        }

        public List<Target> GetListForWork()
        {
            using var context = new NuevoContext();
            DateTime date = DateTime.Now;
            var result = context.Targets.AsQueryable();
            return result.Where(u => u.EndOfPeriod >= date && u.StartOfPeriod <= date).ToList();
        }
        public List<Target> GetListForHomePage()
        {
            using var context = new NuevoContext();
            DateTime date = DateTime.Now;
            var result = context.Targets.AsQueryable();
            return result.Include(u => u.Status).Where(u => u.EndOfPeriod >= date && u.StartOfPeriod <= date).OrderBy(u=> u.Status.FirstOrDefault().CheckDateTime).ToList();
        }
    }
}
