using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class DomainRepository : BaseRepository<Domain.Domain>, IDomainRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public DomainRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
