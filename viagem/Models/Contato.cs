using System.ComponentModel.DataAnnotations;

namespace viagem.Models
{
    public class Contato
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone")]
        public string Telefone { get; set; }
    }
}
