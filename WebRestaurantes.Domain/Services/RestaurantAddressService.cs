namespace WebRestaurantes.Domain
{
    public class RestaurantAddressService : BaseService<RestaurantAddress, IRestaurantAddressRepository>, IRestaurantAddressService
    {
        public RestaurantAddressService(IRestaurantAddressRepository restaurantRepository) : base(restaurantRepository)
        {

        }
    }
}
