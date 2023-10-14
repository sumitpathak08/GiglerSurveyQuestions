using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infra.Interfaces
{
    public interface IRepository<T> where T : class
    {

        
        void AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsync();        
        Task<IList<T>> ExecuteSPAsync(string spName, params (string, object)[] parameters);      
        int Commit();
    }
}
