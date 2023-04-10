//####################################################
//   XDBOX PROJECT
//   Date				Updater				Content
//   06/04/2023         Anh Đô              Create new 
//####################################################

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XDBOX.DATA.RepositoryBase
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> DbSet { get { return DbContext.Set<T>(); } }

        public DbContext DbContext { get; set; }

        public void Delete(T t)
        {
            DbSet.Remove(t);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsyn()
        {
            return await DbSet.ToListAsync();
        }

        public Task<T> GetAsyn(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).SingleOrDefaultAsync();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> GetManyAsyn(Expression<Func<T, bool>> expression)
        {
            return await DbSet.Where(expression).ToListAsync();
        }

        public void Insert(T t)
        {
            DbSet.Add(t);
        }

        public void Update(T t)
        {
            DbSet.Update(t);
        }
    }
}
