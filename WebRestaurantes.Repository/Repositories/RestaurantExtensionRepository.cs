using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class RestaurantExtensionRepository : BaseRepository<RestaurantExtension>, IRestaurantExtensionRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public RestaurantExtensionRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
