using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chinook.WebApi.Repository
{
    public interface IRepository<T>
    {
        Task<int> Create(T entity);
        Task<IEnumerable<T>> Read();
        Task<T> ReadById(object id);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
