using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class Kvittering
    {

        public int kvitteringsNr { get; set; }

        public int dato { get; set; }

        public String personNavn { get; set; }

        public String telefonnummer { get; set; }

        public Object flyfoto { get; set; } 

        public Object kartBilde { get; set; }

        public  String epost { get; set; }

        public int Status { get; set; }

        public String tema { get; set; }

        public String kommentar { get; set; }

        public Object vedlegg { get; set; }


        public Kvittering() {
        
        }

    }

}