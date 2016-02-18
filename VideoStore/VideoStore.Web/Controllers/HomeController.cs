using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.Services;
using VideoStore.Services.Common;
using PagedList;
using PagedList.Mvc;

namespace VideoStore.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private IMoviesService movieService;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for home controller.
        /// </summary>
        public HomeController()
        {
            movieService = new MoviesService();
        }

        #endregion

        // GET: Home
        public ActionResult Index(string sortBy, int? page, int pageSize = 12)
        {
            ViewBag.CurrentSort = sortBy;
            ViewBag.SortTitleParameter = String.IsNullOrEmpty(sortBy) ? "Title desc" : "";
            ViewBag.SortCategoryParameter = sortBy == "Category" ? "Category desc" : "Category";
            ViewBag.SortRatingParameter = sortBy == "Rating" ? "Rating desc" : "Rating";

            int pageNumber = (page ?? 1);

            IEnumerable<Movie> movies = movieService.GetAllMovies(sortBy,pageNumber,pageSize).ToPagedList(pageNumber,pageSize);
            movieService.MoviesChangedStatus(movies, pageNumber, pageSize);

            return View(movies);
        }

        /// <summary>
        /// Gets new movie.
        /// </summary>
        /// <returns>Index page.</returns>
        public ActionResult NewMovie()
        {
            ViewBag.Categories = new SelectList(movieService.GetMovieCategories(), "Id", "Name");

            return View(new Movie());
        }

        /// <summary>
        /// Posts new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        /// <returns>Index page.</returns>
        [HttpPost]
        public ActionResult NewMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieService.NewMovie(movie);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(movieService.GetMovieCategories(), "Id", "Name");

            return View();
        }
        
        /// <summary>
        /// Cancel action.
        /// </summary>
        /// <returns>Returns to home page.</returns>
        public ActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// More details about the movie.
        /// </summary>
        /// <returns>More details page.</returns>
        public ActionResult MoreDetails(Guid id)
        {            
            return View(movieService.GetMovie(id));
        }

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Home page.</returns>
        public ActionResult DeleteMovie(Guid id)
        {
            movieService.DeleteMovie(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Rents a movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Home page.</returns>
        public ActionResult RentMovie (Guid id)
        {
            movieService.RentMovie(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Returns a movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Index page.</returns>
        public ActionResult ReturnMovie (Guid id)
        {
            movieService.ReturnMovie(id);

            return RedirectToAction("Index");
        }
    }
}