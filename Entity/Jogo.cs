using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.Entity
{
    public class Jogo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Produtora { get; set; }

        [Required]
        public double Preco { get; set; }
    }
}
