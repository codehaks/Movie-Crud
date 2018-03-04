using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCrud.Data;
using MovieCrud.Models;
using System.Linq;

namespace MovieCrud.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _db;

        public MovieController(MovieDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.Movies.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Movie model)
        {
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var model = _db.Movies.SingleOrDefault(m => m.Id == id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = _db.Movies.SingleOrDefault(m => m.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Movie model)
        {
            _db.Entry(model).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = _db.Movies.SingleOrDefault(m => m.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}