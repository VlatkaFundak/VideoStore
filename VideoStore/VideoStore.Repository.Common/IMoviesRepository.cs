using System.Collections.Generic;
using VideoStore.Models;

namespace VideoStore.Repository.Common
{
    /// <summary>
    /// Movies repository interface.
    /// </summary>
    public interface IMoviesRepository
    {

        IEnumerable<Movie> GetAllMovies(int pageNumber, int pageSize);

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        IEnumerable<Status> GetMovieStatuses();

        /// <summary>
        /// Gets chosen movie.
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
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        IEnumerable<Category> GetMovieCategories();

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        void DeleteMovie(System.Guid id);

        /// <summary>
        /// Saves data to base.
        /// </summary>
        void SaveStatusToBase();
    }
}
