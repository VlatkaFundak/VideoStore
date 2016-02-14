﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using VideoStore.Repository;
using VideoStore.Repository.Common;
using VideoStore.Services.Common;

namespace VideoStore.Services
{
    public class MoviesService: IMoviesService
    {
        #region Fields

        /// <summary>
        /// Movie repository.
        /// </summary>
        private IMoviesRepository movieRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MoviesService()
        {
            movieRepository = new MoviesRepository();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Rents a movie.
        /// </summary>
        /// <param name="id">Id.</param>
        public void Rent(Guid id)
        {
            Movie movie = movieRepository.GetMovie(id);
            movie.DateExpired = DateTime.Now.AddDays(7);

            movie.StatusId = movieRepository.GetMovieStatuses().ToList().Where(item => item.Name == "Rented").First().Id;
            movieRepository.SaveStatusToBase();
        }

        /// <summary>
        /// Returns movie.
        /// </summary>
        /// <param name="id">Id.</param>
        public void ReturnMovie (Guid id)
        {
            Movie movie = movieRepository.GetMovie(id);

            movie.StatusId = movieRepository.GetMovieStatuses().ToList().Where(item => item.Name == "Available").First().Id;
            movie.DateExpired = null;
            movieRepository.SaveStatusToBase();
        }
        
        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        public IEnumerable<Movie> GetAllMovies(string sortBy)
        {
            IEnumerable<Movie> movies = movieRepository.GetAllMovies();
            var listOfStatuses = movieRepository.GetMovieStatuses().ToList();
            
            foreach (var item in movies)
            {
                if (item.DateExpired <= DateTime.Now)
                {                
                    item.StatusId = listOfStatuses.Where(model => model.Name == "Rented(exp)!").First().Id;
                }
            }

            movieRepository.SaveStatusToBase();         
            movies = from s in movies
                          select s;

            switch (sortBy)
            {
                case "Title desc":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                case "Category":
                    movies = movies.OrderBy(s => s.Category.Name);
                    break;
                case "Category desc":
                    movies = movies.OrderByDescending(s => s.Category.Name);
                    break;
                case "Rating desc":
                    movies = movies.OrderByDescending(s => s.Rating);
                    break;
                case "Rating":
                    movies = movies.OrderBy(s => s.Rating);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }

            return movies;
        }

        #endregion
    }
}
