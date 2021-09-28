using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public class SchedulingService : BaseService<Scheduling, ISchedulingRepository>, ISchedulingService
    {
        IRestaurantService _restaurantService;
        public SchedulingService(ISchedulingRepository schedulingRepository, IRestaurantService restaurantService) : base(schedulingRepository)
        {
            _restaurantService = restaurantService;
        }

        public Task<List<Scheduling>> GetScheduleByRestaurant(int restaurantId)
        {
            return _repository.GetScheduleByRestaurant(restaurantId);
        }

        public List<Scheduling> GetAvailableScheduling(int? restaurantId, DateTime? scheduleDate, TimeSpan? scheduleTime, string restaurantVendorId = null)
        {
            Restaurant restaurant = null;
            int? restaurantIdToSearch = restaurantId;

            if(!string.IsNullOrEmpty(restaurantVendorId))
            {
                restaurant = _restaurantService.GetRestaurantByVendorId(restaurantVendorId);
            }            
            
            if(restaurant != null)
            {
                restaurantIdToSearch = restaurant.Id;
            }

            return _repository.GetAvailableScheduling(restaurantIdToSearch.Value, scheduleDate, scheduleTime);
        }
    }
}
