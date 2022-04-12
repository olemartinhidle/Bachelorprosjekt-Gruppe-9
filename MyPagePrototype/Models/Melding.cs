using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyPagePrototype.Models
{
    
    public class Melding
    {
        // Pri nøkkel
        public int MeldingID { get; set; }

        // Meldingsdato property med formatering
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime MeldingDato { get; set; }

        // Meldingstittel property
        public string MeldingTittel { get; set; } 
        // MeldingAvsender property
        public string MeldingAvsender { get; set; }
        // Melding fil path
        public string MeldingFilPath { get; set; }
        
        // Fremmed nøkkel
        public int BrukerID { get; set; }

        //En melding skal ha en bruker , defineres i FluentAPI/ onModelCreation i context
        public virtual Bruker Bruker { get; set; }
    }

}
