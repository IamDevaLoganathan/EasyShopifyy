using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopify.DataAccess.Repository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll (Expression<Func<T, bool>>? filter=null, string? includeProperties=null);
        T Get (Expression<Func<T, bool>> filter);
        void Add(T Entity);
        void Remove (T Entity);
        void RemoveRange(IEnumerable<T> Entities);

    }
}
