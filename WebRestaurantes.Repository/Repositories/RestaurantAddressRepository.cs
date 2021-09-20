using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class RestaurantAddressRepository : BaseRepository<RestaurantAddress>, IRestaurantAddressRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public RestaurantAddressRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
