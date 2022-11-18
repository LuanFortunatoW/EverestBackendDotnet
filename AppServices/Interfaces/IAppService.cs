using DomainModels;
using DomainServices.Interfaces;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IAppService<S, T> where S : IService<T> where T : BaseModel
    {
        void Create(T model);
        void Update(T model);
        void Delete(long id);
        IEnumerable<T> GetAll();
        T GetById(long id);
    }
}
