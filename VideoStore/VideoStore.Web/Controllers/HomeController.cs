using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Repository.Common;
using VideoStore.Repository;
using VideoStore.Models;

namespace VideoStore.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            IMoviesRepository GetMovies = new MoviesRepository();
            //GetMovies.NewObject();

            return View(GetMovies.GetAllMovies().ToList());
        }

        public ActionResult NewMovie()
        {
            return View(new VideoStore.Models.Movie());
        }

        //[HttpPost]
        //public ActionResult NewMovie(Movie item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        item.Id = Guid.NewGuid();

        //        var entity = new 
            
        //    }
        //}



        public ActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}