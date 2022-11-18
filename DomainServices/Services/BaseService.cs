using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class BaseService<T> : IService<T> where T : BaseModel
    {
        private readonly List<T> _models = new();

        public virtual void Create(T model)
        {
            model.Id = _models.LastOrDefault()?.Id + 1 ?? 1;

            _models.Add(model);
        }

        public virtual void Delete(long id)
        {
            T model = GetById(id);

            _models.Remove(model);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _models;
        }

        public virtual T GetById(long id)
        {
            var result = _models.FirstOrDefault(model => model.Id == id)
                ?? throw new ArgumentNullException($"Id: {id} not found");

            return result;
        }

        public virtual void Update(T model)
        {
            var index = _models.FindIndex(_model => _model.Id == model.Id);
            if (index == -1)
                throw new ArgumentNullException($"Id: {model.Id} not found");

            _models[index] = model;
        }
    }
}