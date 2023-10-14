using Microsoft.EntityFrameworkCore;
using Survey.EFCore.DataContext;
using Survey.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository.Infra_Implement
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly SurveyDBContext _context;
        private readonly DbSet<T> _dbSet;
        protected BaseRepository(SurveyDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void AddAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            int result = 0;
            try
            {
                result = this._context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            var findAll = await _context.Set<T>().Where(predicate).ToListAsync();
            return findAll.AsEnumerable();
        }
        public async Task<List<T>> GetAllAsync()
        {
            var getAll = await _context.Set<T>().ToListAsync();

            return getAll;
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> set = _context.Set<T>().Where(predicate);

            return await includes.Aggregate(set, (current, include) => current.Include(include)).ToListAsync();

            // return (await includes.Aggregate(set, (current, include) => current.Include(include)).ToListAsync() ?? default(IEnumerable<T>));
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> set = _context.Set<T>().Where(predicate);

            return (await includes.Aggregate(set, (current, include) => current.Include(include)).FirstOrDefaultAsync() ?? default(T));
        }
        public async Task<T> GetAsync(int id)
        {
            T o = await _context.Set<T>().FindAsync(id);
            if (o == null)
            {
                throw new Exception("Record Not Found", new KeyNotFoundException("Record Not Found"));
            }
            return o;
        }

        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
        public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public bool Exists(Func<T, bool> conditions)
        {
            return _dbSet.Any(conditions);
        }
        public async Task<T> GetEntityAsyn(Func<T, bool> predicate)
        {
            var oEntity = await _context.Set<T>().ToListAsync();
            var oEntityFilter = oEntity.Where(predicate).FirstOrDefault();//SingleOrDefault();
            return oEntityFilter;
        }
        public T GetEntity(Func<T, bool> predicate)
        {
            var oEntity = _context.Set<T>().ToList().Where(predicate).SingleOrDefault();

            return oEntity;
        }       
        public async Task<IList<T>> ExecuteSPAsync(string spName, params (string, object)[] parameters)
        {
            return new List<T>();
            //return await spExtension.ExecuteStoredProcedureAsync<T>(spName, parameters);
        }
    }
}
