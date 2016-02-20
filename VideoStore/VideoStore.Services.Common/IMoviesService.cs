﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using VideoStore.Common.Filters;

namespace VideoStore.Services.Common
{
    public interface IMoviesService
    {
        /// <summary>
        /// Rents a movie.
        /// </summary>
        /// <param name="id">Id.</param>
        void RentMovie(Guid id);

        /// <summary>
        /// Returns movie.
        /// </summary>
        /// <param name="id">Id.</param>
        void ReturnMovie(Guid id);

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Gets collection of all movies.</returns>
        IEnumerable<Movie> GetAllMovies(MoviesFilter filter);

        /// <summary>
        /// Changes status of the movie.
        /// </summary>
        /// <returns>Movie.</returns>
        void MoviesChangedStatus(IEnumerable<Movie> movies, MoviesFilter filter);

        /// <summary>
        /// Gets certain movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        Movie GetMovie(System.Guid id);

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        void NewMovie(Movie movie);

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        void DeleteMovie(System.Guid id);

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        IEnumerable<Status> GetMovieStatuses();

        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        IEnumerable<Category> GetMovieCategories();

    }
}
