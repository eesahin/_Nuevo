using _Nuevo.Entities.Concrete;

namespace _Nuevo.Business.Interfaces
{
    public interface IStatuService : IBaseService<Statu>
    {
        Statu GetStatuForTargetId(int id);
    }
}
