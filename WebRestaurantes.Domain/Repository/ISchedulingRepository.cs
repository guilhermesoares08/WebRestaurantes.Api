using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface ISchedulingRepository : IBaseRepository<Scheduling>
    {
        Task<List<Scheduling>> GetScheduleByRestaurant(int restaurantId);
    }
}
