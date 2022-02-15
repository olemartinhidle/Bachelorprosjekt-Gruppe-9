using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class Case
    {
        public int caseNr { get; set; }
        public int owner { get; set; }

        public int date { get; set; }

        public int topic { get; set; }

        public int caseMessage { get; set; }

        public int response { get; set; }

        public Case()
        {


        }

    }
}