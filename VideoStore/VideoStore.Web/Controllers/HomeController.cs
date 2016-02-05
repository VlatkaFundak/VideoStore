using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Repository.Common;
using VideoStore.Repository;
using VideoStore.Models;
using VideoStore.Services;

namespace VideoStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMoviesRepository movieRepository;

        /// <summary>
        /// Constructor for home controller.
        /// </summary>
        public HomeController()
        {
            movieRepository = new MoviesRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            //movieRepository.NewObject();

            return View(movieRepository.GetAllMovies().ToList());
        }

        // GET: New movie
        public ActionResult NewMovie()
        {
            ViewBag.Categories = new SelectList(movieRepository.GetMovieCategories(), "Id", "Name");

            return View(new Movie());
        }

        //POST: New movie
        [HttpPost]
        public ActionResult NewMovie(Movie movie)
        {
            ViewBag.Categories = new SelectList(movieRepository.GetMovieCategories(), "Id", "Name");

            if (ModelState.IsValid)
            {               
                movieRepository.NewMovie(movie);
                return RedirectToAction("Index");
            }

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

        public ActionResult RentMovie (Guid id)
        {
            SetMovieStatusToRented setStatus = new SetMovieStatusToRented();
            setStatus.Rent(id);

            return RedirectToAction("Index");
        }
    }
}