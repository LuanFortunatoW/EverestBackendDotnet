using DomainModels;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface IService<T> where T : BaseModel
    {
        void Create(T model);
        void Update(T model);
        void Delete(long id);
        IEnumerable<T> GetAll();
        T GetById(long id);
    }
}