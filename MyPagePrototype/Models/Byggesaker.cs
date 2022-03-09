using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class Byggesaker
    {

        protected int sakNr;

        protected String eier;

        protected String dato;

        protected String tema;

        protected String sakbeskjed;

        protected String svar;

        public List<Sak> byggesaker = new List<Sak>();

        }   

        

    }
