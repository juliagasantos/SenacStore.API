using System.ComponentModel.DataAnnotations;

namespace SenacStore.API.DTOs
{
    public class UsuarioInputDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MaxLength(10)]
        public string Senha { get; set; }
    }
}
