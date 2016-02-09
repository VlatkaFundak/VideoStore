using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;

namespace VideoStore.Services.Common
{
    public interface IMoviesService
    {
        /// <summary>
        /// Rents a movie.
        /// </summary>
        /// <param name="id">Id.</param>
        void Rent(Guid id);

        /// <summary>
        /// Returns movie.
        /// </summary>
        /// <param name="id">Id.</param>
        void ReturnMovie(Guid id);

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        IEnumerable<Movie> GetAllMovies();
    }
}
