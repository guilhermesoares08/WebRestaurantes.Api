using System;
using WebRestaurantes.Domain;

namespace WebRestaurantes.WebAPI.Dtos
{
    public class RestaurantExtensionDto
    {
        
        public int Id { get; set; }

        public Guid? OptionId { get; set; }

        public int RestaurantId { get; set; }

        public bool IsActive { get; set; }
    }
}