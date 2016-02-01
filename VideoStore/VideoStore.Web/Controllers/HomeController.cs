using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Repository.Common;
using VideoStore.Repository;


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
    }
}