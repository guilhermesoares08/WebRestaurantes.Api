using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface ISchedulingService : IBaseService<Scheduling>
    {
        Task<List<Scheduling>> GetScheduleByRestaurant(int restaurantId);
    }
}
