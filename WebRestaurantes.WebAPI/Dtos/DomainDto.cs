using System.ComponentModel.DataAnnotations;

namespace WebRestaurantes.WebAPI.Dtos
{
    public class DomainDto
    {
        public int Id { get; set; }
        [StringLength (100, MinimumLength=3, ErrorMessage="{0} é entre 3 e 100 Caracters")]
        public string Description { get; set; }
        [Required (ErrorMessage="O Campo {0} é Obrigatório")]
        public string Value { get; set; }

        public bool IsActive { get; set; }
    }
}