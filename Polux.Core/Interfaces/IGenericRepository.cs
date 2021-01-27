using Polux.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polux.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
