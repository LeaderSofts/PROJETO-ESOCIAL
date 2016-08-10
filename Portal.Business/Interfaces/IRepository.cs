using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Business.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T FindSingleBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAllBy(Expression<Func<T, bool>> predicate);
        int Save(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Delete(Expression<Func<T, bool>> predicate);
    }
}
