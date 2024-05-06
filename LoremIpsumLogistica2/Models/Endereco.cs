using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica2.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string UF { get; set; }
        public Cliente Cliente { get; set; }
    }
}
