using System.Collections.Generic;

namespace KinoOpolwood.Models
{
    public class SearchViewModel
    {
        public List<Bilet> Bilets { get; set; }
        public List<Film> Films { get; set; }
        public List<Klient> Klients { get; set; }
        public List<Miejsce> Miejsces { get; set; }
        public List<Sala> Salas { get; set; }
        public List<Seans> Seanss { get; set; }
    }
}