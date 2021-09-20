using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface ITableRepository : IBaseRepository<Table>
    {
        Task<List<Table>> GetTablesByRestaurant(int restaurantId);
    }
}
