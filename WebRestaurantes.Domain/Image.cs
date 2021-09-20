using System;

namespace WebRestaurantes.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Extension { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; }
    }
}