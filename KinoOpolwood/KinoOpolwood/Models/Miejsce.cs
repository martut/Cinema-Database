using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinoOpolwood.Models
{
    public class Miejsce
    {
        public int MiejsceId { get; set; }
        public int SalaId { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }



        public virtual Sala Sala { get; set; }
    }
}