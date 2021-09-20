using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public class RestaurantService : BaseService<Restaurant, IRestaurantRepository>, IRestaurantService
    {
        public RestaurantService(IRestaurantRepository restaurantRepository) : base (restaurantRepository)
        {

        }

        public Task<List<Restaurant>> GetAllRestaurantAsync(bool includeImages = false)
        {
            return _repository.GetAllRestaurantAsync(includeImages);
        }

        public Task<Restaurant> GetRestaurantAsyncById(int id, bool includeImages = false)
        {
            return _repository.GetRestaurantAsyncById(id, includeImages);
        }

        public Task<List<Restaurant>> GetRestaurantAsyncByText(string text)
        {
            return _repository.GetRestaurantAsyncByText(text);
        }
    }
}
