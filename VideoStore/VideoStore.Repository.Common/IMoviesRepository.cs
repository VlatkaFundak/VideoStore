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
        /// Enumerable of movies.
        /// </summary>
        /// <returns>Movies.</returns>
        IEnumerable<Movie> GetAllMovies();

        //void NewObject();
    }
}
