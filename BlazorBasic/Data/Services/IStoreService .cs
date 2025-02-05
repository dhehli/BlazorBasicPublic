using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBasic.Data
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(int id);
        Task AddStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(int id);
    }
}