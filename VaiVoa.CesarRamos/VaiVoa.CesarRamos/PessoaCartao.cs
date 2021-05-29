using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaivoa.CesarRamos
{
    [Table("TB_PESSOA_CARTAO")]
    public class PessoaCartao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NumeroCartaoVirtual { get; set; }
    }
}