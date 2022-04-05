using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPagePrototype.Models
{
    public class ByggesakInnboks
    {
        // Primærnøkkel 
        public int ByggesakInnboksID { get; set; }
        // Foreign key
        public int BrukerID { get; set; }
        // Foreign key
        public int ByggesakID { get; set; }
        // En byggesakinnboks skal ha en bruker
        
        [Required]
        public virtual Bruker Bruker { get; set; }
        // En byggesak innboks kan ha flere byggesaker
        [Required]
        public virtual Byggesak Byggesak { get; set; }


    }
}