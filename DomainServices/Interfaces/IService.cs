using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
