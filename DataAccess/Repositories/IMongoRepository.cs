using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IMongoRepository <T>
    {
        Task Save(T model);
        Task SaveRange(IEnumerable<T> models);
        Task Update(T model);
        Task Remove(string id);
        Task RemoveRange(IEnumerable<T> models);
        IQueryable<T> AsQueryable();
        Task<T> GetById(string id);
        Task<List<T>> FindByProperty(string property, string search);
    }
}
