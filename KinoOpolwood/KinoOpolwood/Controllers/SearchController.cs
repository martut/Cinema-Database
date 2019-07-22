using KinoOpolwood.DAL;
using KinoOpolwood.Models;
using KinoOpolwood.SearchModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KinoOpolwood.Controllers
{
    public class SearchController : Controller
    {
        KinoContext db = new KinoContext();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result(string query)
        {
            var bilets = db.Bilets
                .Where(b => b.Price.ToString().Contains(query))
                .ToList();

            var films = db.Films
                .Where(f => f.Director.Contains(query)
                || f.Title.Contains(query)
                || f.LenghtTime.ToString().Contains(query))
                .ToList();

            var klients = db.Klients
                .Where(k => k.Adress.Contains(query)
                || k.FirstName.Contains(query)
                || k.LastName.Contains(query))
                .ToList();

            var miejsces = db.Miejsces
                .Where(m => m.RowNumber.ToString().Contains(query)
                || m.SeatNumber.ToString().Contains(query))
                .ToList();

            //var rezerwacjas = db.Rezerwacjas.Where(r => r) //??
            var salas = db.Salas
                .Where(s => s.NumberOfSeats.ToString().Contains(query)
                || s.RoomNumber.ToString().Contains(query))
                .ToList();

            var seanss = db.Seanss
                .Where(s => s.StartDate.ToString().Contains(query))
                .ToList();

            var vm = new SearchViewModel
            {
                Bilets = bilets,
                Films = films,
                Klients = klients,
                Miejsces = miejsces,
                Salas = salas,
                Seanss = seanss
            };

            return View(vm);
        }

        public ActionResult Film()
        {
            return View();
        }

        public ActionResult FilmResult(FilmSearchModel filmSearchModel)
        {
            var films = db.Films.ToList();

            if (!string.IsNullOrEmpty(filmSearchModel.Title))
                films = films.Where(f => f.Title.Contains(filmSearchModel.Title))
                    .ToList();

            if (!string.IsNullOrEmpty(filmSearchModel.Director))
                films = films.Where(f => f.Director.Contains(filmSearchModel.Director))
                    .ToList();

            if(!string.IsNullOrEmpty(filmSearchModel.From) &&
                !string.IsNullOrEmpty(filmSearchModel.To))
                films = films
                    .Where(f => f.LenghtTime > TimeSpan.Parse(filmSearchModel.From) &&
                    f.LenghtTime < TimeSpan.Parse(filmSearchModel.To))
                    .ToList();
            else if(!string.IsNullOrEmpty(filmSearchModel.From))
                films = films.Where(f => f.LenghtTime > TimeSpan.Parse(filmSearchModel.From))
                    .ToList();
            else if(!string.IsNullOrEmpty(filmSearchModel.To))
                films = films.Where(f => f.LenghtTime < TimeSpan.Parse(filmSearchModel.To))
                    .ToList();

            var seanss = films.Select(f =>
            {
                return db.Seanss.Where(seans => seans.FilmId == f.FilmId).ToList();

            }).ToList();


            return View();
        }
    }
}