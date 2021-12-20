using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace viagem.Models
{
    [Table("Destino")]
    public class Destino
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o local de destino")]
        public string LocalViagem { get ; set; }

        [Required(ErrorMessage = "Informe a data de ida")]
        public string DataIda { get; set; }
        
        public string DataVolta { get; set; }

        [Required(ErrorMessage = "Informe o nome do passageiro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a idade do passageiro")]
        public int Idade { get; set; }
    }
}
