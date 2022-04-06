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
        public int MeldingID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime MeldingDato { get; set; }
        public string MeldingTittel { get; set; } 
        public string MeldingAvsender { get; set; }
        public string MeldingFilPath { get; set; }
        public int BrukerID { get; set; }

        public virtual Bruker Bruker { get; set; }
    }

}
