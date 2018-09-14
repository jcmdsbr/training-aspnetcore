using ApiAngular.Models;
using System;
using System.Collections.Generic;

namespace ApiAngular.Infra.Repository.Contracts
{
    public interface IRepositoryBase<T> where T : Entity
    {
        T Add(T entity);

        T Update(T entity);

        void Remove(Guid id);

        List<T> GetAll();

        T GetById(Guid id);

        T GetBy(Func<T, bool> predit);

        bool Commit();
    }
}