using System;

namespace KinoOpolwood.Models
{
    public class Seans
    {

        public int SeansId { get; set; }
        public int FilmId { get; set; }
        public int SalaId { get; set; }
        public DateTime StartDate { get; set; }


        public virtual Film Film { get; set; }

        public virtual Sala Sala { get; set; }
    }
}