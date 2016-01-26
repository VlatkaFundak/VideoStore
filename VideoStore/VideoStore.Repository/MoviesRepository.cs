﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.DAL;
using VideoStore.Models;

namespace VideoStore.Repository
{
    public class MoviesRepository
    {
        MovieContext MovieContext { get; set; }

        public void NewObject()
        {
            MovieContext = new MovieContext();

            var CategoryObject = new Category();
            CategoryObject.Id = Guid.NewGuid();
            CategoryObject.Name = "Comedy";
            MovieContext.Categories.Add(CategoryObject);

            var StatusObject = new Status();
            StatusObject.Id = Guid.NewGuid();
            StatusObject.Name = "Available";
            MovieContext.Statuses.Add(StatusObject);

            var MovieObject = new Movie();
            MovieObject.Id = Guid.NewGuid();
            MovieObject.Name = "Meet the Millers";
            MovieObject.Description = "Comedy movie";
            MovieObject.Rating = 7.9;
            MovieObject.DateCreated = DateTime.Now;
            MovieObject.DateUpdated = DateTime.Now;
            MovieObject.CategoryId = CategoryObject.Id;
            MovieObject.StatusId = StatusObject.Id;
            MovieContext.Movies.Add(MovieObject);

            MovieContext.SaveChanges();
        }

        public DbSet<Movie> GetAllMovies()
        {
            MovieContext = new MovieContext();

            return (MovieContext.Movies);
        }
    }
}