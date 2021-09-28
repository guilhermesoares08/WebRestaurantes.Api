using System;
using System.Collections.Generic;
using System.Text;

namespace WebRestaurantes.Domain
{
    public class ScheduleFilter
    {
        public ScheduleFilter()
        {
            this.ScheduleTime = DateTime.Now.TimeOfDay;
            this.ScheduleDate = DateTime.Now.Date;
        }

        public TimeSpan? ScheduleTime { get; set; }

        public DateTime? ScheduleDate { get; set; }

        public string RestaurantVendorId { get; set; }
    }
}
