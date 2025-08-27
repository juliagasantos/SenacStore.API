﻿using System.ComponentModel.DataAnnotations;

namespace SenacStore.API.DTOs
{
    public class CadastroOutputDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Nro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
