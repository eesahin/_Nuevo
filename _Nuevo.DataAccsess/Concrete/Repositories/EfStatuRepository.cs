using System;
using System.Linq;
using _Nuevo.DataAccsess.Concrete.EntityFrameworkCore.Context;
using _Nuevo.DataAccsess.Interfaces;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.DataAccsess.Concrete.Repositories
{
    public class EfStatuRepository : EfBaseRepository<Statu>, IStatuDal
    {
        public Statu GetStatuForTargetId(int id)
        {
            using var context = new NuevoContext();
            var data = context.Status.FirstOrDefault(u => u.TargetId == id);
            if (data == null)
            {
                Statu newStatu = new Statu
                {
                    IsSendAnEmail = false,
                    CheckDateTime = DateTime.Now,
                    TargetId = id,
                    Code = "Not Checked Yet",
                };
                context.Set<Statu>().Add(newStatu);
                context.SaveChanges();
                return newStatu;
            }
            return data;
        }
    }
}
