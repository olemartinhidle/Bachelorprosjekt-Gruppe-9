using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyPagePrototype.Models
{
    public class Byggesak
    {
        public int ByggesakID { get; set; }
        public string ByggesakTema { get; set; }
        public string TypeBygg { get; set; }
        public int ByggningsNummer { get; set; }

        private const string DEFAULT_TITTEL = "Din nye byggesak";
        private string _tittel = DEFAULT_TITTEL;
        [DefaultValue(DEFAULT_TITTEL)]
        public string ByggesakTittel
        {
            get { return _tittel; }
            set { _tittel = value; }
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ByggesakDato { get{ return byggesakDato ?? DateTime.Now; } 
            set{ this.byggesakDato = value; } }

        private DateTime? byggesakDato = null;
        public string ByggesakStatus { get; set; }
        public string NæringsGruppe { get; set; }
        public int NyttAreal { get; set; }
        public int NyHøyde { get; set; }

        
        public int? KvitteringID { get; set; }

        public int BrukerID { get; set; }

        
       
        public virtual Kvittering Kvittering { get; set; }
        public virtual Bruker Bruker { get; set; }

    }

}
