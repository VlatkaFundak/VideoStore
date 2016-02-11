using System;
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
            movieRepository.SaveStatusToBase();
        }

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            IEnumerable<Movie> movies = movieRepository.GetAllMovies();

            foreach (var item in movies)
            {
                if (item.DateExpired <= DateTime.Now)
                {
                    item.StatusId = movieRepository.GetMovieStatuses().ToList().Where(model => model.Name == "Rented(exp)!").First().Id;
                }
            }

            movieRepository.SaveStatusToBase();

            return movies;
        }

        #endregion
    }
}
