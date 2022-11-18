using AppServices.Interfaces;
using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class BaseAppService<S, T> : IAppService<S, T> where S : IService<T> where T : BaseModel
    {

        private readonly S _service;
        public BaseAppService(S service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public virtual void Create(T model)
        {
            _service.Create(model);
        }

        public virtual void Delete(long id)
        {
            _service.Delete(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _service.GetAll();
        }

        public virtual T GetById(long id)
        {
            return _service.GetById(id);
        }

        public virtual void Update(T model)
        {
            _service.Update(model);
        }
    }
}
