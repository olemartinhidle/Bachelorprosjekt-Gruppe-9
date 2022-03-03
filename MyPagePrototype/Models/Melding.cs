using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class Melding : Innboks
    {

        public int meldingsID { get; set; }

        public String meldingsNavn { get; set; }


        public String status { get; set; }


        public  String fil { get; set; }

        public Melding()
        {
            meldingsID = 0;
            meldingsNavn = "Byggesak";
            status = "Under behandling";
            fil = "dette/er/en/path/";

        }

        public int CompareTo(Melding other)
        {
            throw new NotImplementedException();
        }
    }


}