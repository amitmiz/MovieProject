using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieProject.Controllers
{
    public class QuereiesController : Controller
    {
        private  MovieProjectContext _context;
        //private readonly JavaScriptSerializer _jsonSerializer;

        public QuereiesController(MovieProjectContext context)
        {
            this._context = context;
            //this._jsonSerializer = new JavaScriptSerializer();
        }

        public List<Movie> GetMostExpensiveMovies(int p_topToTake)
        {
            var movies = this._context.Movie.OrderByDescending(x => x.Price).Take(p_topToTake).ToList();
            return movies;
        }
        public List<Movie> GetChippestMovies(int p_topToTake)
        {
            var movies = this._context.Movie.OrderBy(x => x.Price).Take(p_topToTake).ToList();
            return movies;
        }
        
        public object GetMoviesGroupedBySuppliers()
        {
            var movies = this._context.Movie
               .Join(this._context.Supplier,
                     m => m.SupplierId,
                     s => s.ID,
                     (m, s) => new {
                         Title = m.Title,
                         Supplier = s.Name
                     }
                     ).GroupBy(x=>x.Supplier).ToArray();
           
            return movies;
        }

        public object  GetMoviesGroupByReleaseYear()
        {
           var movies = this._context.Movie.GroupBy(x=> x.ReleaseDate.Year)
                                          .OrderByDescending(x => x.Count())
                                          .ToArray();
            return movies;
        }

        public object GetMoviesByGenre()
        {
            var Movies = this._context.Movie.GroupBy(x => x.Genre)
                                          .OrderByDescending(x => x.Count()
                                          );
            return Movies;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(this.GetMoviesGroupedBySuppliers());
        }
    }
}
