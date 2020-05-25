using System.Collections.Generic;
using _Nuevo.Business.Interfaces;
using _Nuevo.DataAccsess.Interfaces;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.Business.Concrete
{
    public class StatuManager : IStatuService
    {
        private readonly IStatuDal _statuDal;
        public StatuManager(IStatuDal statuDal)
        {
            _statuDal = statuDal;
        }
        public void Add(Statu obj)
        {
            _statuDal.Add(obj);
        }
        public void Delete(Statu obj)
        {
            _statuDal.Delete(obj);
        }
        public Statu GetItem(int id)
        {
            return _statuDal.GetItem(id);
        }
        public List<Statu> GetList()
        {
            return _statuDal.GetList();
        }
        public Statu GetStatuForTargetId(int id)
        {
            return _statuDal.GetStatuForTargetId(id);
        }
        public void Update(Statu obj)
        {
            _statuDal.Update(obj);
        }
    }
}
