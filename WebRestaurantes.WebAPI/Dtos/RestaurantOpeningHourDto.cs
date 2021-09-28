using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestaurantes.WebAPI
{
    public class RestaurantOpeningHourDto
    {
        public TimeSpan? OpeningTime { get; set; }

        public TimeSpan? ClosingTime { get; set; }
    }
}
