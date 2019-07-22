using KinoOpolwood.DAL;
using KinoOpolwood.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KinoOpolwood.Controllers
{
    public class CreatorController : Controller
    {
        KinoContext db = new KinoContext();
        Random rnd = new Random();

        public ActionResult MiejsceCreator(int? id)
        {
            var salas = db.Salas.ToList();

            foreach (var sala in salas)
            {
                var miejsce = new Miejsce
                {
                    SalaId = sala.SalaId
                };

                int numOfRows = sala.NumberOfSeats / 10;
                for (int i = 0; i < numOfRows; i++)
                {

                    miejsce.RowNumber = i + 1;
                    for (int j = 1; j <= 10; j++)
                    {
                        miejsce.SeatNumber = j;
                        db.Miejsces.Add(miejsce);
                        db.SaveChanges();
                    }
                }

            }

            return RedirectToAction("Index", "Miejsces");
        }

        public ActionResult SeansCreator(int? id)
        {
            var films = db.Films.ToList();
            var salas = db.Salas.ToList();

            for (int i = 0; i < id; i++)
            {
                var film = films.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                var sala = salas.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                var seans = new Seans()
                {
                    FilmId = film.FilmId,
                    SalaId = sala.SalaId,
                    StartDate = RndDateTime()
                };
                db.Seanss.Add(seans);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Seans");
        }

        public ActionResult RezerwacjaCreator(int? id)
        {
            var miejsces = db.Miejsces.ToList();
            var klients = db.Klients.ToList();
            var seans = db.Seanss.ToList();

            for (int i = 0; i < id; i++)
            {
                var rezerwacja = new Rezerwacja
                {
                    KlientId = klients.OrderBy(x => Guid.NewGuid()).FirstOrDefault().KlientId,
                    MiejsceId = miejsces.OrderBy(x => Guid.NewGuid()).FirstOrDefault().MiejsceId,
                    SeansId = seans.OrderBy(x => Guid.NewGuid()).FirstOrDefault().SeansId
                };

                db.Rezerwacjas.Add(rezerwacja);

            }

            db.SaveChanges();

            return RedirectToAction("Index", "Rezerwacjas");
        }

        public ActionResult SalasCreator(int? id)
        {
            for (int i = 0; i < id; i++)
            {
                var sala = new Sala
                {
                    RoomNumber = i,
                    NumberOfSeats = rnd.Next(5, 10) * 10
                };

                db.Salas.Add(sala);
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Salas");
        }

        public ActionResult BiletsCreator(int? id)
        {
            var seanss = db.Seanss.ToList();
            var miejsces = db.Miejsces.ToList();

            foreach (var seans in seanss)
            {
                var miejscesSeanse = miejsces.Where(x => x.SalaId == seans.SalaId).ToList();

                foreach (var miejsce in miejscesSeanse)
                {
                    var bilet = new Bilet
                    {
                        MiejsceId = miejsce.MiejsceId,
                        SeansId = seans.SeansId,
                        Price = 15
                    };

                    db.Bilets.Add(bilet);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index", "Bilets");
        }

        public ActionResult FilmCreator(int? id)
        {
            var directors = new[]
            {"Christopher Nolan", "Steven Spilberg", "Patryk Vegeta", "Misiek Koterski", "Łesli Snajps", "Steven Geyer"};

            var titles = new[]
            {
                "1954", "Wolność, Własność, TVN", "Propagadna w czasach PiSu", "Wolna Polska tylko z PISem",
                "IPhone zbawiciel", "W tył ku akcji", "Memberberries", "Rick And Morty"
            };

            for (int i = 0; i < id; i++)
            {
                var film = new Film()
                {
                    Director = directors[rnd.Next(0, directors.Length - 1)],
                    Title = titles[rnd.Next(0, titles.Length - 1)],
                    LenghtTime = new TimeSpan(rnd.Next(0, 3), rnd.Next(0, 59), rnd.Next(0, 59))
                };

                db.Films.Add(film);
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Films");
        }

        public ActionResult KlientCreator(int? id)
        {
            var firstNames = new[]
            {
                "Paweł", "Maciek", "Kasia", "Adam", "Justyna", "Kamil", "Wojtek", "Agnieszka", "Basia", "Izabela",
                "Klaudia"
            };
            var lastNames = new[]
            {
                "Sobieszczański", "Wirzeski", "Kowalski", "Stysiak", "Wojnarowski", "Włodarczyk", "Pyjor", "Słomian",
                "Pieczara", "Sowa"
            };
            var adresses = new[] { "Opole", "Warszawa", "Wódka", "Węgry", "Kup", "Prudnik", "Wrocław", "Poznań", "Łodź" };

            for (int i = 0; i < id; i++)
            {
                var klient = new Klient()
                {
                    Adress = adresses[rnd.Next(0, adresses.Length - 1)],
                    FirstName = firstNames[rnd.Next(0, firstNames.Length - 1)],
                    LastName = lastNames[rnd.Next(0, lastNames.Length - 1)]
                };

                db.Klients.Add(klient);
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Klients");
        }

        private DateTime RndDateTime()
        {
            DateTime start = DateTime.Now;

            start = start.AddDays(rnd.Next(31));
            start = start.AddHours(rnd.Next(-24, 24));
            start = start.AddMinutes(rnd.Next(-60, 60));

            return start;
        }

    }
}