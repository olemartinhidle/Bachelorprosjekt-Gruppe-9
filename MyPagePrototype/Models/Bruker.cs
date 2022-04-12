using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPagePrototype.Models
{
    // Bruker klassen
    public class Bruker
    {
        // Setter at listen ikke skal generere ID av seg selv
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        // Pri nøkkel property
        public int BrukerID { get; set; }
        // Navn property
        public string Navn { get; set; }
        // Passord property
        public int Passord { get; set; }
        // Telefonnummer property
        public string Telefonnummer { get; set; }
        // Epost property
        public string Epost { get; set; }

        // Forholdene defineres under
        // En bruker skal ha flere kontaktinfo, defineres i FluentAPI/ onModelCreation i context
        public virtual ICollection<KontaktInfo> KontaktInfo { get; set; }
        // En bruker skal ha flere byggesaker, defineres i FluentAPI/ onModelCreation i context
        public virtual ICollection<Byggesak> Byggesaker { get; set; }
        // En bruker skal ha flere meldinger, defineres i FluentAPI/ onModelCreation i context
        public virtual ICollection<Melding> Meldinger { get; set; }

    }
}