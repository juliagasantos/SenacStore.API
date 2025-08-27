using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenacStore.API.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; }
    }
}
