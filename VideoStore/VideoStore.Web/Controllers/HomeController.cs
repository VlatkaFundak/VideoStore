using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Repository.Common;
using VideoStore.Repository;
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

        private IMoviesRepository movieRepository;
        private IMoviesService movieService;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for home controller.
        /// </summary>
        public HomeController()
        {
            movieRepository = new MoviesRepository();
            movieService = new MoviesService();
        }

        #endregion

        // GET: Home
        public ActionResult Index(int? page, string sortBy)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);

            ViewBag.SortTitleParameter = String.IsNullOrEmpty(sortBy) ? "Title desc" : "";
            ViewBag.SortCategoryParameter = sortBy == "Category" ? "Category desc" : "Category";
            ViewBag.SortRatingParameter = sortBy == "Rating" ? "Rating desc" : "Rating";

            List<Movie> movies = movieService.GetAllMovies(sortBy).ToList();           

            return View(movies.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Gets new movie.
        /// </summary>
        /// <returns>Index page.</returns>
        public ActionResult NewMovie()
        {
            ViewBag.Categories = new SelectList(movieRepository.GetMovieCategories(), "Id", "Name");

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
                movieRepository.NewMovie(movie);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(movieRepository.GetMovieCategories(), "Id", "Name");

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
            return View(movieRepository.GetMovie(id));
        }

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Home page.</returns>
        public ActionResult DeleteMovie(Guid id)
        {
            movieRepository.DeleteMovie(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Rents a movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Home page.</returns>
        public ActionResult RentMovie (Guid id)
        {
            movieService.Rent(id);

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