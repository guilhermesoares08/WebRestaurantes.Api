using System;
using System.ComponentModel.DataAnnotations;
using WebRestaurantes.Domain;

namespace WebRestaurantes.WebAPI.Dtos
{
    public class RestaurantAddressDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public string Address { get; set; }
        public string Number { get; set; }
        public int? CityId { get; set; }
        public string Street { get; set; }

        public int RestaurantId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public City City { get; }
    }
}