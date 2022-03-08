using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class Sak : Byggesaker
    {
        public String Eier { get; set; }
        public int SakNr { get; set; }
        public String Dato { get; set; }
        public String Tema { get; set; }
        public String Sakbeskjed { get; set; }
        public String Svar { get; set; }

        private int sakNr;

        private String eier;

        private String dato;

        private String tema;

        private String sakbeskjed;

        private String svar;

        public Sak(int sakNr, String eier, String dato, String tema, String sakbeskjed, String svar)
        {
            this.sakNr = sakNr;
            this.eier = eier;
            this.dato = dato;
            this.tema = tema;
            this.sakbeskjed = sakbeskjed;
            this.svar = svar;

        }


    }

    
}