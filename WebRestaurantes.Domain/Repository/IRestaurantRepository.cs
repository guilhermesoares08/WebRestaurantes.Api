using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface IRestaurantRepository : IBaseRepository<Restaurant>
    {
        Task<List<Restaurant>> GetAllRestaurantAsync(bool includeImages = false);

        Task<Restaurant> GetRestaurantAsyncById(int id, bool includeImages = false);

        Task<List<Restaurant>> GetRestaurantAsyncByText(string text);        
    }
}
