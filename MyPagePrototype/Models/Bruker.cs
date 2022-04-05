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
        /* Felt */
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        /* Prop, gettere og settere */

        public int BrukerID { get; set; }
        public string Navn { get; set; }
        public string Telefonnummer { get; set; }
        public string Epost { get; set; }
        public bool MailØnsket { get; set; }
        public bool Samtykke { get; set; }


        public virtual ICollection<Innboks> Innboks { get; set; }

        public virtual ICollection<ByggesakInnboks> ByggesakInnboks { get; set; }

        public virtual ICollection<KontaktInfo> KontaktInfo { get; set; }

        


    }
}