﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.DAL;
using VideoStore.Models;
using VideoStore.Repository.Common;

using PagedList;
using PagedList.Mvc;

namespace VideoStore.Repository
{
    /// <summary>
    /// Movies repository class.
    /// </summary>
    public class MoviesRepository: IMoviesRepository
    {
        #region Fields

        /// <summary>
        /// Gets or sets movie context.
        /// </summary>
        private MovieContext MovieContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MoviesRepository()
        {
            MovieContext = new MovieContext();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets certain movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        public Movie GetMovie(Guid id)
        {
            try
            {
                var selectedMovie = MovieContext.Movies.ToList().Find(item => item.Id == id);

                return selectedMovie;
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }


        public IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize)
        {
            try
            {
                return MovieContext.Movies.OrderBy(item => item.Title).ToPagedList(pageNumber, pageSize).AsEnumerable();
            }
            catch (Exception e)
            {                
                throw e;
            }
        }

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        public void NewMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();

            try
            {
                movie.StatusId = MovieContext.Statuses.Where(item => String.Equals(item.Name, "Available")).First().Id;
                movie.DateCreated = DateTime.Now;
                movie.DateUpdated = DateTime.Now;

                MovieContext.Movies.Add(movie);
                MovieContext.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        
        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        public void DeleteMovie(Guid id)
        {
            try
            {
                MovieContext.Movies.Remove(GetMovie(id));
                MovieContext.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        /// <summary>
        /// Saves data to base.
        /// </summary>
        public void SaveStatusToBase()
        {
            try
            {
                MovieContext.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        public IEnumerable<Status> GetMovieStatuses()
        {
            return MovieContext.Statuses;
        }

        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        public IEnumerable<Category> GetMovieCategories()
        {
            return MovieContext.Categories;
        }

        #endregion

    }
}
