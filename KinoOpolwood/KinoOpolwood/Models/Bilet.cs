using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinoOpolwood.Models
{
    public class Bilet
    {
        public int BiletId { get; set; }
        public decimal Price { get; set; }
        public int MiejsceId { get; set; }
        public int SeansId { get; set; }


        public virtual Miejsce Miejsce { get; set; }
        public virtual Seans Seans { get; set; }
    }
}