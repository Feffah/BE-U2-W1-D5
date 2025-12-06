using System.ComponentModel.DataAnnotations;

namespace BE_U2_W1_D5.Models.Entity
{
    public class TipoViolazione
    {
        [Key]
        public int IDViolazione { get; set; }
        [Required]
        public string Descrizione { get; set; }
    }
}
