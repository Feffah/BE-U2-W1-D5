using System.ComponentModel.DataAnnotations;

namespace BE_U2_W1_D5.Models.Entity
{
    public class Anagrafica
    {
        [Key]
        public int IDAnagrafica { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Indirizzo { get; set; }
        [Required]
        public string Citta { get; set; }
        [Required]

        public int CAP { get; set; }
        [Required]

        public string CodiceFiscale { get; set; }

        public ICollection<Verbale> Verbali { get; set; }
    }
}
