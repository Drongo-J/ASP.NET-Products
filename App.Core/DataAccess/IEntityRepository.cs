using App.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
