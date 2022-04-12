using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPagePrototype.Models
{
    public class Byggesak
    {
        // Setter at den ikke skal generere ID selv
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // Pri nøkkel for byggesak
        public int ByggesakID { get; set; }
        // Byggesak tema property
        public string ByggesakTema { get; set; }
        // Type bygg property
        public string TypeBygg { get; set; }
        // Bygningsnummer property
        public int ByggningsNummer { get; set; }

        // Default verdier for en ny byggesakstittel
        private const string DEFAULT_TITTEL = "Din nye byggesak";
        private string _tittel = DEFAULT_TITTEL;
        [DefaultValue(DEFAULT_TITTEL)]
        // Property for byggesakstittel
        public string ByggesakTittel
        {
            get { return _tittel; }
            set { _tittel = value; }
        }

        // Annotering for å sette dato som sys.date om denne verdien skulle være tom
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        // Byggesak dato property med formatering og default
        public DateTime ByggesakDato { get{ return byggesakDato ?? DateTime.Now; } 
            set{ this.byggesakDato = value; } }

        private DateTime? byggesakDato = null;
        // Byggesaksstatus property
        public string ByggesakStatus { get; set; }
        // Næringsgruppe property
        public string NæringsGruppe { get; set; }
        // Nytt areal property
        public int NyttAreal { get; set; }
        // Ny høyde property
        public int NyHøyde { get; set; }

        // Kan ha en kvittering property, fremmed nøkkel
        public int? KvitteringID { get; set; }

        // Fremmed nøkkel
        public int BrukerID { get; set; }

        
       // En byggesak kan ha en kvittering, defineres i FluentAPI/ onModelCreation i context
        public virtual Kvittering Kvittering { get; set; }
        //En byggesak skal ha en bruker , defineres i FluentAPI/ onModelCreation i context
        public virtual Bruker Bruker { get; set; }

    }

}
