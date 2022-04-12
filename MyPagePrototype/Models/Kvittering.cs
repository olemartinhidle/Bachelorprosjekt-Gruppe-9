using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPagePrototype.Models
{
    public class Kvittering
    {
        // Pri nøkkel
        public int KvitteringID { get; set; }

        // Dato property med formatering
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime KvitteringsDato { get; set; }
        //Kommentar til kvittering
        public string Kommentar { get; set; }
        // Path til vedlegg
        public string Vedlegg { get; set; }
        // Path til matrikkelfoto
        public string MatrikkelPath { get; set; }
        // Path til ortofoto
        public string OrtoPath { get; set; }
        // Fremmed nøkkel
        public int ByggesakID { get; set; }
        // Fremmed nøkkel
        public int KontaktInfoID { get; set; }

        //Kvittering skal ha en byggesak, defineres i FluentAPI/ onModelCreation i context
        public virtual Byggesak Byggesak { get; set; }
        //Kvittering skal ha en kontaktinfo, defineres i FluentAPI/ onModelCreation i context
        public virtual KontaktInfo KontaktInfo { get; set; }

    }

}