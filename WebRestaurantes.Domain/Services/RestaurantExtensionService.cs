
namespace WebRestaurantes.Domain
{
    public class RestaurantExtensionService : BaseService<RestaurantExtension, IRestaurantExtensionRepository>, IRestaurantExtensionService
    {
        public RestaurantExtensionService(IRestaurantExtensionRepository restaurantExtensionRepository) : base(restaurantExtensionRepository)
        {
        }
    }
}
