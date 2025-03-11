using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capirchio_BlockBuster;
using Microsoft.AspNetCore.Mvc.Rendering;
using Capirchio_BlockBuster.Models;
using BlockBusterWebApp.Helpers;

namespace BlockBusterWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var movie = BlockBusterBasicFunctions.GetFullMovieById(id);
            return View(movie);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            var genres = new SelectList(BlockBusterBasicFunctions.GetAllGenres()
                .OrderBy(g => g.GenreDescr)
                .ToDictionary(g => g.GenreId, g => g.GenreDescr), "Key", "Value");
            ViewBag.GenreId = genres;

            var directors = new SelectList(BlockBusterBasicFunctions.GetAllDirectors()
                .OrderBy(d => d.LastName)
                .ToDictionary(d => d.DirectorId, d => d.LastName + ", " + d.FirstName), "Key", "Value");
            ViewBag.DirectorId = directors;
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movieToCreate)
        {
            try
            {
                BlockBusterAdminFunctions.AddMovie(movieToCreate);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            /*var movie = BlockBusterBasicFunctions.GetFullMovieById(id);
            var genres = new SelectList(BlockBusterBasicFunctions.GetAllGenres()
                .OrderBy(g => g.GenreDescr)
                .ToDictionary(g => g.GenreId, g => g.GenreDescr), "Key", "Value");
            ViewBag.GenreId = genres;

            var directors = new SelectList(BlockBusterBasicFunctions.GetAllDirectors()
                .OrderBy(d => d.LastName)
                .ToDictionary(d => d.DirectorId, d => d.LastName + ", " + d.FirstName), "Key", "Value");
            ViewBag.DirectorId = directors;
            return View(movie);*/

            var movie = BlockBusterBasicFunctions.GetFullMovieById(id);
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.DirectorId = DropDownFormatter.FormatDirectors();
            return View(movie);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movieToEdit)
        {
            try
            {
                BlockBusterAdminFunctions.EditMovie(movieToEdit);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = BlockBusterBasicFunctions.GetFullMovieById(id);
            return View(movie);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
            try
            {
                BlockBusterAdminFunctions.DeleteMovie(movie.MovieId);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
