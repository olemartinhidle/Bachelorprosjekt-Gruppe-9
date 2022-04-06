using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPagePrototype.Models
{
    public class Bruker
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        

        public int BrukerID { get; set; }
        public string Navn { get; set; }
        public int Passord { get; set; }
        public string Telefonnummer { get; set; }
        public string Epost { get; set; }


        public virtual ICollection<KontaktInfo> KontaktInfo { get; set; }
        public virtual ICollection<Byggesak> Byggesaker { get; set; }
        public virtual ICollection<Melding> Meldinger { get; set; }

    }
}