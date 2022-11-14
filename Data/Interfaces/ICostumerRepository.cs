using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    internal interface ICostumerRepository
    {
        void Create(Costumer costumer);
        bool Update(Costumer costumer);
        bool Delete(long  id);
        List<Costumer> GetAll();
        Costumer GetById(int id);
    }
}
