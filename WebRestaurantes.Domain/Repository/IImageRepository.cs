using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        //Task<List<Image>> GetImagesByRestaurant(int restaurantId);
    }
}
