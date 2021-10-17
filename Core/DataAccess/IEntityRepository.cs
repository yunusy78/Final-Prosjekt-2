using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    //generic constraint
    // class refrans tip
    // IEntity veya IEntity implemente eden nesnede olabilir
    // new demek yenilenebilir demek bundan dolayi IENtity yazamazsiniz

    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}