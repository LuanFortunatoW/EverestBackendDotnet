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

        public virtual bool Delete(long id)
        {
            T model = GetById(id);

            return _models.Remove(model);
        }

        public virtual List<T> GetAll()
        {
            return _models;
        }

        public virtual T GetById(long id)
        {
            var result = _models.FirstOrDefault(model => model.Id == id);

            if (result is null)
                throw new ArgumentException($"Id {id} not found");

            return result;
        }

        public virtual bool Update(T model)
        {
            int index = _models.FindIndex(_model => _model.Id == model.Id);
            if (index == -1)
                return false;

            model.Id = _models[index].Id;
            _models[index] = model;

            return true;
        }
    }
}