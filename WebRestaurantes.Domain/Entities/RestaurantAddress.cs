using System;
using System.Collections.Generic;

namespace WebRestaurantes.Domain
{
    public class RestaurantAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public int? CityId { get; set; }
        public string Street { get; set; }
        public int RestaurantId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Restaurant Restaurant { get; }
        public City City { get; set; }
    }
}