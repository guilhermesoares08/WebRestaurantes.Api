using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface ISchedulingService : IBaseService<Scheduling>
    {
        Task<List<Scheduling>> GetScheduleByRestaurant(int restaurantId);

        List<Scheduling> GetAvailableScheduling(int? restaurantId, DateTime? scheduleDate, TimeSpan? scheduleTime, string restaurantVendorId);
    }
}
