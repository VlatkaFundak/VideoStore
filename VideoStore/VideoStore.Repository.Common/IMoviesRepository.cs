using System.Collections.Generic;
using VideoStore.Models;
using VideoStore.Common.Filters;
using System.Threading.Tasks;

namespace VideoStore.Repository.Common
{
    /// <summary>
    /// Movies repository interface.
    /// </summary>
    public interface IMoviesRepository
    {

        Task<IEnumerable<Movie>> GetAllMoviesAsync(MoviesFilter filter);

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        Task<IEnumerable<Status>> GetMovieStatusesAsync();

        /// <summary>
        /// Gets chosen movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        Task<Movie> GetMovieAsync(System.Guid id);

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        Task NewMovieAsync(Movie movie);

        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        Task<IEnumerable<Category>> GetMovieCategoriesAsync();

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        Task DeleteMovieAsync(System.Guid id);

        /// <summary>
        /// Saves data to base.
        /// </summary>
        Task SaveStatusToBase();
    }
}
