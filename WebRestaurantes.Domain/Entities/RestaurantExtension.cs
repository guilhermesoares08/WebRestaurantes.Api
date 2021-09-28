using System;

namespace WebRestaurantes.Domain
{
    public class RestaurantExtension
    {
        public int Id { get; set; }

        public Guid? DomainValueId { get; set; }

        public int RestaurantId { get; set; }

        public bool IsActive { get; set; }

        public DomainValue DomainValue { get; set; }

        public RestaurantExtension()
        {
            IsActive = true;
        }
    }
}