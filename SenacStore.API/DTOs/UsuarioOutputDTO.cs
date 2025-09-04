﻿using System.ComponentModel.DataAnnotations;

namespace SenacStore.API.DTOs
{
    public class UsuarioOutputDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
