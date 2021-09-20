using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public class TableService : BaseService<Table, ITableRepository>, ITableService
    {
        public TableService(ITableRepository tableRepository) : base(tableRepository)
        {
        }

        public async Task<IList<Table>> GetTablesByRestaurant(int restaurantId)
        {
            return await _repository.GetTablesByRestaurant(restaurantId);
        }
    }
}
