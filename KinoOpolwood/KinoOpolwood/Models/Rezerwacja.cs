using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinoOpolwood.Models
{
    public class Rezerwacja
    {
        public int RezerwacjaId { get; set; }
        public int MiejsceId { get; set; }
        public int KlientId { get; set; }
        public int SeansId { get; set; }


        public virtual Miejsce Miejsce { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Seans Seans { get; set; }
    }
}