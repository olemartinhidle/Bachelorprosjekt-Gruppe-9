using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class Profil
    {

        public int profilID { get; set; }

        public String navn { get; set; }

        public String telefonnummer { get; set; }

        public String epost { get; set; }

        public bool mailØnsket { get; set; }

        public bool samtykke { get; set; }
    }
}