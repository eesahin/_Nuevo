using _Nuevo.Entities.Concrete;

namespace _Nuevo.DataAccsess.Interfaces
{
    public interface IStatuDal : IBaseDal<Statu>
    {
        Statu GetStatuForTargetId(int id);
    }
}
