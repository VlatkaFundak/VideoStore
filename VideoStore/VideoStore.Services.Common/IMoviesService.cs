using System;
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
        Task RentMovie(Guid id);

        /// <summary>
        /// Returns movie.
        /// </summary>
        /// <param name="id">Id.</param>
        Task ReturnMovie(Guid id);

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Gets collection of all movies.</returns>
        Task<IEnumerable<Movie>> GetAllMoviesAsync(MoviesFilter filter);

        /// <summary>
        /// Changes movie status.
        /// </summary>
        /// <param name="movies">Movies.</param>
        Task MoviesChangedStatus(IEnumerable<Movie> movies);

        /// <summary>
        /// Gets certain movie.
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
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        Task DeleteMovieAsync(System.Guid id);

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        Task<IEnumerable<Status>> GetMovieStatuses();

        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        Task<IEnumerable<Category>> GetMovieCategories();

    }
}
