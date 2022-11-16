using DomainModels;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    internal interface IService<T> where T : BaseModel
    {
        void Create(T model);
        bool Update(T model);
        bool Delete(long id);
        List<T> GetAll();
        T GetById(long id);
    }
}