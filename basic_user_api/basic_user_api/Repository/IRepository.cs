using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basic_user_api.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T toCreate);
        Task<T> Update(int id, T toUpdate);
        Task<bool> Delete(int idToDelete);
    }
}
