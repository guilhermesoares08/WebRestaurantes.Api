using System;
using System.Collections.Generic;
using System.Text;

namespace WebRestaurantes.Domain.Entities
{
    public class RestaurantActivate
    {
        public RestaurantActivate()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public int RestaurantId { get; set; }

        public bool IsActivated { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
