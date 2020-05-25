using System.Collections.Generic;
using _Nuevo.Business.Interfaces;
using _Nuevo.DataAccsess.Interfaces;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.Business.Concrete
{
    public class TargetManager : ITargetService
    {
        private readonly ITargetDal _targetDal;
        public TargetManager(ITargetDal targetDal)
        {
            _targetDal = targetDal;
        }
        public void Add(Target obj)
        {
            _targetDal.Add(obj);
        }
        public void Update(Target obj)
        {
            _targetDal.Update(obj);
        }
        public void Delete(Target obj)
        {
            _targetDal.Delete(obj);
        }
        public Target GetItem(int id)
        {
            return _targetDal.GetItem(id);
        }
        public List<Target> GetList()
        {
            return _targetDal.GetList();
        }
        public List<Target> GetList(out int count, int page, string search)
        {
            return _targetDal.GetList(out count, page, search);
        }
        public List<Target> GetListForWork()
        {
            return _targetDal.GetListForWork();
        }
        public List<Target> GetListForHomePage()
        {
            return _targetDal.GetListForHomePage();
        }
    }
}
