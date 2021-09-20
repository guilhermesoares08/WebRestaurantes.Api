using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public RestaurantRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Restaurant>> GetAllRestaurantAsync(bool includeImages = true)
        {
            IQueryable<Restaurant> query = _webRestaurantesContext.Restaurants;
            query = query.Include(d => d.Address);
            query = query.Include(d => d.Owner);
            if (includeImages)
            {
                query = query.Include(r => r.Images);
            }
            query = query.AsNoTracking().OrderBy(p => p.Description);
            return await query.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantAsyncById(int id, bool includeImages = true)
        {
            IQueryable<Restaurant> query = _webRestaurantesContext.Restaurants;
            query = query.Include(r => r.Address)
                            .ThenInclude(a => a.City)
                            .ThenInclude(c => c.State);

            query = query.Include(r => r.Extensions)
                            .ThenInclude(r => r.DomainValue);
            if (includeImages)
            {
                query = query.Include(r => r.Images);
            }
            query = query.AsNoTracking().Where(r => r.Id.Equals(id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantAsyncByText(string text)
        {
            IQueryable<Restaurant> query = _webRestaurantesContext.Restaurants;
            query = query.Include(r => r.Images).Include(r => r.Address);
            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToLower();

                query = query.AsNoTracking().Where(r => r.Description.ToLower().Contains(text));

            }
            //sem AsNoTracking = pode manipular
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
    }
}
