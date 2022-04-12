using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPagePrototype.Models
{
    public class KontaktInfo
    {
        // Pri nøkkel for kontaktinfo
        public int KontaktInfoID { get; set; }
        // Navn property
        public string Navn { get; set; }
        // Telefonnummer property
        public string Telefonnummer { get; set; }
        // Epost property
        public string Epost { get; set; }
        // Mail ønsket property
        public bool MailØnsket { get; set; }

        // Samtykke property, med error om ikke avmerket
        [Range(typeof(bool), "true", "true", ErrorMessage = "Må markeres*")]
        public bool Samtykke { get; set; }

        // Fremmed nøkkel
        public int BrukerID { get; set; }

        //Kontaktinfo kan ha en kvittering, defineres i FluentAPI/ onModelCreation i context
        public virtual Kvittering Kvittering { get; set; }
        //Kontaktinfo skal ha en bruker, defineres i FluentAPI/ onModelCreation i context
        public virtual Bruker Bruker { get; set; }

    }
}