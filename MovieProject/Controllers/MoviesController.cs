using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ing System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;

namespace MovieProject.Controllers

{
    public class MoviesController : Controller
    {
        private readonly MovieProjectContext _context;
        //ivate readonly JavaScriptSerializer _jsonSerializer;

        public MoviesController(MovieProjectContext context)
        {
            //this._jsonSerializer = new JavaScriptSerializer();
            _context = context;
        }

        public List<Movie> GetMoviesByGenre(string p_genre)
        {
            var movies = this._context.Movie.Where(x => x.Genre == p_genre).ToList();
            return movies;
        }

        public List<Movie> GetMoviesByDirector(string p_director)
        {
            var movies = this._context.Movie.Where(x => x.Director.Name == p_director).ToList();
            return movies;
        }
        public List<Movie> GetMoviesByReleaseYear(int p_releaseYear)
        {
            var movies = this._context.Movie.Where(x => x.ReleaseDate.Year == p_releaseYear).ToList();
            return movies;
        }
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }
        public IActionResult Search()
        {
            return View(this.GetMoviesBySearchParams(null, null, "Geeks", null));
        }
        public List<Movie> GetMoviesBySearchParams(string p_movieTitle = null, int? p_releaseYear = null, string p_genre = null, string p_director = null)
        {

            var queryOver = this._context.Movie.AsQueryable();

            if (!string.IsNullOrEmpty(p_movieTitle))
            {
                queryOver = queryOver.Where(x => x.Title == (p_movieTitle));
            }
            if (p_releaseYear.HasValue)
            {
                queryOver = queryOver.Where(x => x.ReleaseDate.Year == p_releaseYear.Value);
            }
            if (!string.IsNullOrEmpty(p_genre))
            {
                queryOver = queryOver.Where(x => x.Genre == p_genre);
            }
            if (!string.IsNullOrEmpty(p_director))
            {
                queryOver = queryOver.Where(x => x.Director.Name == p_director);
            }

            var result = queryOver.Select(x => new Movie { Title = x.Title, ReleaseDate = x.ReleaseDate, Genre = x.Genre, Price = x.Price }).ToList();

            // return this._jsonSerializer.Serialize(result); // Run the query and avoid context dispose
            return result;

        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}

