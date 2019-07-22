using System;

namespace KinoOpolwood.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public TimeSpan LenghtTime { get; set; }
        public string Director { get; set; }
    }
}