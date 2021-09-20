using System.ComponentModel.DataAnnotations;

namespace WebRestaurantes.WebAPI.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage="O Campo {0} é Obrigatório")]
        public string URL { get; set; }
        public string Extension { get; set; }        
    }
}