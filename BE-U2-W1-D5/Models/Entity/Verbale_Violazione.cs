
using System.ComponentModel.DataAnnotations;

namespace BE_U2_W1_D5.Models.Entity
{
    public class Verbale_Violazione
    {
        public int IDVerbale { get; set; }

        public int IDViolazione { get; set; }

        public Verbale verbale { get; set; }

        public TipoViolazione violazione { get; set; }

    }
}
