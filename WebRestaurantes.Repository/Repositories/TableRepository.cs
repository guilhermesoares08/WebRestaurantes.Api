using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public TableRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Table>> GetTablesByRestaurant(int restaurantId)
        {
            IQueryable<Table> query = _webRestaurantesContext.Tables;
            
            query = query.AsNoTracking().Where(r => r.RestaurantId.Equals(restaurantId));
            return await query.ToListAsync();
        }
    }
}
