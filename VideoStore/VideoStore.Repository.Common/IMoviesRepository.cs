using System.Collections.Generic;
using VideoStore.Models;

namespace VideoStore.Repository.Common
{
    /// <summary>
    /// Movies repository interface.
    /// </summary>
    public interface IMoviesRepository
    {
        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        IEnumerable<Movie> GetAllMovies();

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        IEnumerable<Status> GetAllStatuses();

        /// <summary>
        /// Gets chosen movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        Movie GetMovie(System.Guid id);

        //TODO: obrisati naknadno, kreiram ručno objekt tu
        ///<summary>
        ///New movie.
        ///</summary>
        void NewObject();

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        /// <returns>Movie.</returns>
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

        //TODO: obrisati naknadno, kreiram ručno objekt tu
        System.Guid AvailableStatus();

        //TODO: obrisati naknadno, kreiram ručno objekt tu
        System.Guid RentedStatus();

        //TODO: obrisati naknadno, kreiram ručno objekt tu
        System.Guid ExpiredRent();

        /// <summary>
        /// Saves data to base.
        /// </summary>
        void SaveStatusToBase();
    }
}
