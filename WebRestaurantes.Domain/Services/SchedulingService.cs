using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public class SchedulingService : BaseService<Scheduling, ISchedulingRepository>, ISchedulingService
    {
        public SchedulingService(ISchedulingRepository schedulingRepository) : base(schedulingRepository)
        {

        }

        public Task<List<Scheduling>> GetScheduleByRestaurant(int restaurantId)
        {
            return _repository.GetScheduleByRestaurant(restaurantId);
        }
    }
}
