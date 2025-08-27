using System.ComponentModel.DataAnnotations;

namespace SenacStore.API.DTOs
{
    public class ProdutoInputDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [MaxLength(500)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A imagem é obrigatória.")]
        [MaxLength(250)]
        public string Imagem { get; set; }

        [Range(1, 5, ErrorMessage = "A nota do produto é obrigatória, sendo de 1 a 5.")]
        public int Nota { get; set; }

        public bool EhLancamento { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        public decimal Preco { get; set; }

        public int CategoriaId { get; set; }
    }
}
