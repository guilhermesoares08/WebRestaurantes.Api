using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public ImageRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
