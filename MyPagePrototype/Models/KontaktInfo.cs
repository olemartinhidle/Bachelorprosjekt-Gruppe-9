using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPagePrototype.Models
{
    public class KontaktInfo
    {
        
        public int KontaktInfoID { get; set; }
        public string Navn { get; set; }
        public string Telefonnummer { get; set; }
        public string Epost { get; set; }
        public bool MailØnsket { get; set; }
        public bool Samtykke { get; set; }
        //public int? KvitteringID { get; set; }

        public virtual Kvittering Kvittering { get; set; }

    }
}