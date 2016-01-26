﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Repository;

namespace VideoStore.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            MoviesRepository GetMovies = new MoviesRepository();

            return View(GetMovies.GetAllMovies().ToList());
        }
    }
}