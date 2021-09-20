using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface ITableService : IBaseService<Table>
    {
        Task<IList<Table>> GetTablesByRestaurant(int restaurantId);
    }
}
