using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBCore;
//ing System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MovieProject.Controllers

{
    public class MoviesController : Controller
    {
        private readonly MovieProjectContext _context;
        private readonly IConfiguration _configuration;

        //ivate readonly JavaScriptSerializer _jsonSerializer;

        public MoviesController(MovieProjectContext context, IConfiguration Configuration)
        {
            //this._jsonSerializer = new JavaScriptSerializer();
            _context = context;
            _configuration = Configuration;
        }

        public List<Movie> GetMoviesByGenre(string p_genre)
        {
            var movies = this._context.Movie.Where(x => x.Genre == p_genre).ToList();
            return movies;
        }

        public List<Movie> GetMoviesByDirector(string p_director)
        {
            var movies = this._context.Movie.Where(x => x.Director == p_director).ToList();
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
            
            return View(await _context.Movie.Include(x=>x.MovieSupplier).ToListAsync());
        }
        public IActionResult Search(string title = null, int? year = null, string genere = null, string director = null,int? priceFrom=null,int? priceTo=null,int? SupplierId = null)
        {
            PopulateSuppliersDropDownList();
            return View(this.GetMoviesBySearchParams(title, year, genere, director,priceFrom,priceTo, SupplierId));
        }
        public List<Movie> GetMoviesBySearchParams(string p_movieTitle = null, int? p_releaseYear = null, string p_genere = null, string p_director = null ,int? p_priceFrom=null, int? p_priceTo = null,int? p_supplierId=null)
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
            if (!string.IsNullOrEmpty(p_genere))
            {
                queryOver = queryOver.Where(x => x.Genre == p_genere);
            }
            if (!string.IsNullOrEmpty(p_director))
            {
                queryOver = queryOver.Where(x => x.Director == p_director);
            }
            if (p_priceFrom.HasValue)
            {
                queryOver = queryOver.Where(x => x.Price >= p_priceFrom);
            }
            if (p_priceTo.HasValue)
            {
                queryOver = queryOver.Where(x => x.Price <= p_priceTo);
            }
            if (p_supplierId.HasValue)
            {
                // join query with suppliers              
                queryOver = queryOver.Join(this._context.Supplier,
                     m => m.SupplierId,
                     s => s.ID,
                 (m, s) => new Movie { ID = m.ID, Title = m.Title, ReleaseDate = m.ReleaseDate, Genre = m.Genre, Price = m.Price, Director = m.Director, Length = m.Length, MinimalAge = m.MinimalAge, MovieSupplier = s })
                .Where(x=>x.MovieSupplier.ID == p_supplierId.Value);

                //queryOver = queryOver.Where(x => x.MovieSupplier.ID == p_supplierId.Value);
               
            }
            var result = queryOver.Select(x => new Movie { ID=x.ID, Title = x.Title, ReleaseDate = x.ReleaseDate, Genre = x.Genre, Price = x.Price,Director =x.Director, Length=x.Length,MinimalAge=x.MinimalAge,MovieSupplier = x.MovieSupplier }).ToList();

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
            ImdbMovie movieRev= this.GetMovieData(movie.Title);
            if (movie == null)
            {
                return NotFound();
            }

            return View("details",movieRev);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            PopulateSuppliersDropDownList();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Director,Length,MinimalAge,SupplierId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AuthorId = new SelectList(_context.Supplier, "ID", "Name", movie.SupplierId);
            //PopulateSuppliersDropDownList(movie.SupplierId);
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
            PopulateSuppliersDropDownList(movie.MovieSupplier.ID);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Director,Length,MinimalAge")] Movie movie)
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
            PopulateSuppliersDropDownList(movie.MovieSupplier.ID);
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

        public ImdbMovie GetMovieData(string movieName)
        {
            string  API_KEY =  _configuration.GetSection("AppSettings")["ImdbApiKey"];

            var imdb = new Imdb(API_KEY);
            var movie =  imdb.GetMovieAsync(movieName);

           return movie.Result;

            
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
        private void PopulateSuppliersDropDownList(object selectedSupplier = null)
        {
            var suppliersQuery = from d in _context.Supplier
                                   orderby d.Name
                                   select d;
            
            ViewBag.SupplierId = new SelectList(suppliersQuery, "ID", "Name", selectedSupplier);
            //new SelectList()
        }
    }
}

