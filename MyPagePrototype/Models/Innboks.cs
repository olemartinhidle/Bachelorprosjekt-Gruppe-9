using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyPagePrototype.Models
{
    
    public class Innboks
    {
        // Primærnøkkel
        public int InnboksID { get; set; }
        // Foreign key
        public int BrukerID { get; set; }
        // Foreign key
        public int MeldingID { get; set; }


        // Skal ha en bruker
        [Required]
        public virtual Bruker Bruker { get; set; }
        // Skal ha en melding
        [Required]
        public virtual Melding Melding { get; set; }

    }
}