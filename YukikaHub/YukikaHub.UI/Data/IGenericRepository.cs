using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.UI.Data
{
    public interface IGenericRepository<T>
    {
        void Add(T model);
        void Remove(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllNoTrackingAsync();
        Task<T> GetByIdAsync(int id);
        bool HasChanges();
        Task SaveAsync();
    }
}
