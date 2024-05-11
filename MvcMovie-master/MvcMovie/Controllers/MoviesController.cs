using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MvcMovie.Models;
using System.Reflection;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private static List<Movie> listMovies = new List<Movie>();
        public async Task<IActionResult> Index()
        {
            return View(listMovies);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Simulación de creación de un objeto (model)
            //Mas adelante vamos a ver como usar una base de datos
            var movie = listMovies.Find(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Simplemente asignamos un nuevo id como el siguiente número en la lista
                    model.Id = listMovies.Count + 1;
                    listMovies.Add(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al crear la película: " + ex.Message);
            }
            return View(model);
        }

        // GET: ModelController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = listMovies.Find(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: ModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var movieIndex = listMovies.FindIndex(m => m.Id == id);
                    if (movieIndex == -1)
                    {
                        return NotFound();
                    }
                    listMovies[movieIndex] = model;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al editar la película: " + ex.Message);
            }
            return View(model);
        }

        // GET: ModelController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = listMovies.Find(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: ModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Movie model)
        {
            try
            {
                var movieIndex = listMovies.FindIndex(m => m.Id == id);
                if (movieIndex == -1)
                {
                    return NotFound();
                }
                listMovies.RemoveAt(movieIndex);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar la película: " + ex.Message);
            }
            return View(model);
        }
    }
}
