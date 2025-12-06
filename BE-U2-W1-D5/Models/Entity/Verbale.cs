using System.ComponentModel.DataAnnotations;
namespace BE_U2_W1_D5.Models.Entity
{
    public class Verbale
    {
        [Key]
         public int IDVerbale { get; set; }
      public DateTime DataViolazione { get; set; }
      public string IndirizzoViolazione { get; set; }
      public string NominativoAgente { get; set; }
       public DateTime DataTrascrizioneVerbale { get; set; }
       public decimal Importo { get; set; }
       public int DecurtamentoPunti { get; set; }

        public Anagrafica anagrafica { get; set; }

    }
}
