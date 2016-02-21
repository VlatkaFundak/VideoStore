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
using System.Collections;
using VideoStore.Common.Filters;

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

        /// <summary>
        /// Index action.
        /// </summary>
        /// <param name="searchMovie">Search movie.</param>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="ordering">Ordering.</param>
        /// <returns>Index page.</returns>
        public ActionResult Index(Guid? movieCategoryId, Guid? movieStatusId, string searchMovie, int pageNumber = 1, int pageSize = 12, string ordering = "Title")
        {
            MoviesFilter filter = new MoviesFilter(pageNumber, pageSize, ordering, searchMovie, movieStatusId,movieCategoryId);

            ViewBag.Statuses = new SelectList(movieService.GetMovieStatuses(), "Id", "Name");
            ViewBag.Categories = new SelectList(movieService.GetMovieCategories(), "Id", "Name");

            IEnumerable<Movie> movies = movieService.GetAllMovies(filter);
            movieService.MoviesChangedStatus(movies,filter);

            ViewBag.SortTitle = ordering == "Title" ? "Title desc" : "Title";
            ViewBag.SortCategory = ordering == "Category.Name" ? "Category.Name desc" : "Category.Name";
            ViewBag.SortRating = ordering == "Rating" ? "Rating desc" : "Rating";
            ViewBag.SortYear = ordering == "Year" ? "Year desc" : "Year";
            ViewBag.CurrentSort = ordering;
            ViewBag.CurrentSearch = searchMovie;
            ViewBag.CurrentStatus = movieStatusId;
            ViewBag.CurrentCategory = movieCategoryId;

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
        /// <returns>Returns to index page.</returns>
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