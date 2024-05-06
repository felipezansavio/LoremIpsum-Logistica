using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [RegularExpression("^(Masculino|Feminino)$", ErrorMessage = "Sexo deve ser 'Masculino' ou 'Feminino'")]
        public string Sexo { get; set; }
        public List<Endereco> Enderecos { get; set; }

    }
}
