using System.ComponentModel.DataAnnotations;

namespace WebRestaurantes.WebAPI.Dtos
{
    public class TableDto
    {
        
        public int Id { get; set; }

        public string Description { get; set; }

        public int RestaurantId { get; set; }

        [Range(1, 120000)]
        public int Seats { get; set; }

        public string VendorId { get; set; }       

        public bool IsActive { get; set; }

        //está ocupado?
        public bool IsBusy { get; set; }       

    }
}