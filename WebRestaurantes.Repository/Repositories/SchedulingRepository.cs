using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class SchedulingRepository : BaseRepository<Scheduling>, ISchedulingRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;

        public SchedulingRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Scheduling>> GetScheduleByRestaurant(int restaurantId)
        {
            var _query = _webRestaurantesContext.Scheduling.AsQueryable();
            _query = _webRestaurantesContext.Scheduling.FromSqlInterpolated($@"sp_Select_Scheduling {restaurantId}");
            var lstResult = await _query.ToListAsync();
            return lstResult;
        }

        public List<Scheduling> GetAvailableScheduling(int? restaurantId, DateTime? scheduleDate, TimeSpan? scheduleTime)
        {           
            IQueryable<Scheduling> query = _webRestaurantesContext.Scheduling;

            if (restaurantId.HasValue)
            {
                query = query.AsNoTracking().Where(c => c.RestaurantId == restaurantId.Value);
            }

            if(scheduleDate.HasValue)
            {
                query = query.AsNoTracking().Where(c => c.ScheduleDate.Value.Date >= scheduleDate.Value.Date);
            }

            if (scheduleTime.HasValue)
            {
                query = query.AsNoTracking().Where(c => c.ScheduleTime >= scheduleTime);
            }

            return query.ToList();
        }
    }
}
