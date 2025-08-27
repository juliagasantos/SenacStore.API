using System.ComponentModel.DataAnnotations;

namespace SenacStore.API.DTOs
{
    public class CategoriaInputDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; }
    }
}
