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
    public interface IRepository<T> where T: class
    {
        DbSet<T> DbSet { get; }
        DbContext DbContext { get; set; }

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> expression);

        T Get(Expression<Func<T, bool>> expression);

        void Insert(T t);

        void Delete(T t);

        void Update(T t);

        void DeleteRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetAllAsyn();

        Task<IEnumerable<T>> GetManyAsyn(Expression<Func<T, bool>> expression);

        Task<T> GetAsyn(Expression<Func<T, bool>> expression);
    }
}
