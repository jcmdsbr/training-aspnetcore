using ApiAngular.Infra.Repository.Context;
using ApiAngular.Infra.Repository.Contracts;
using ApiAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiAngular.Infra.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected readonly ApiAngularContext ApiAngularContext;

        protected RepositoryBase(ApiAngularContext apiAngularContext)
        {
            ApiAngularContext = apiAngularContext;
        }

        public T Add(T entity)
        {
            ApiAngularContext.Set<T>().Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            ApiAngularContext.Set<T>().Update(entity);

            return entity;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);

            ApiAngularContext.Remove(obj);
        }

        public List<T> GetAll()
        {
            return ApiAngularContext.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return ApiAngularContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T GetBy(Func<T, bool> predit)
        {
            return ApiAngularContext.Set<T>().FirstOrDefault(predit);
        }
        public bool Commit()
        {
            return ApiAngularContext.SaveChanges() > 0;
        }
    }
}