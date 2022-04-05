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
        
        public int KvitteringID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime KvitteringsDato { get; set; }
        public string Kommentar { get; set; }
        public string Vedlegg { get; set; }
        public string MatrikkelPath { get; set; }
        public string OrtoPath { get; set; }

        
        public int ByggesakID { get; set; }
        
        public int KontaktInfoID { get; set; }

        
        
        public virtual Byggesak Byggesak { get; set; }
        
        public virtual KontaktInfo KontaktInfo { get; set; }

    }

}