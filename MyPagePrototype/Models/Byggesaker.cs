using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class Byggesaker
    {
        /*
        public Byggesaker()
        {
            Sak sak = new Sak();

            sak.SakNr = 1;
            sak.Dato = "10.12.2020";
            sak.Tema = "Test";
            sak.Sakbeskjed = "Dette er en test";
            sak.Svar = "Nei takk";

            byggesaker.Add(sak);
        }   */

        public List<Sak> byggesaksliste() {

            List<Sak> byggesaksliste = new List<Sak>(); 

            Sak sak = new Sak();

            sak.SakNr = 1;
            sak.Dato = "10.12.2020";
            sak.Tema = "Test";
            sak.Sakbeskjed = "Dette er en test";
            sak.Svar = "Nei takk";

            byggesaksliste.Add(sak);

            return byggesaksliste; 
        
        }

    }
}