
using System;

namespace WebRestaurantes.Domain
{
    public class Scheduling
    {
        public int Id { get; set; }
        public int? TableId { get; set; }

        public int? RestaurantId { get;set; }

        public int? UserId { get;set; }

        public DateTime? ScheduleDate { get;set; }

        public bool? Expired { get; set; }
        public DateTime? CreateDate { get;set; }

        public DateTime? UpdateDate { get;set; }

    }
}