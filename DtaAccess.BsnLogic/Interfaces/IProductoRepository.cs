using System.Collections.Generic;
using System.Threading.Tasks;
using DtaAccess.BsnLogic.Models;

namespace DtaAccess.BsnLogic.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task DeleteAsync(int id);
    }
}
