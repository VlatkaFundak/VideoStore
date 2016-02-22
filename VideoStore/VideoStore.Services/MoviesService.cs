using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using VideoStore.Repository;
using VideoStore.Repository.Common;
using VideoStore.Services.Common;
using VideoStore.Common.Filters;

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
        public void RentMovie(Guid id)
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
        /// Changes movie status.
        /// </summary>
        /// <param name="movies">Movies.</param>
        public void MoviesChangedStatus(IEnumerable<Movie> movies)
        {
            //movies = movieRepository.GetAllMovies(filter);
            var listOfStatuses = movieRepository.GetMovieStatuses();

            foreach (var item in movies)
            {
                if (item.DateExpired <= DateTime.Now)
                {
                    item.StatusId = listOfStatuses.Where(model => model.Name == "Rented(exp)!").First().Id;
                }
            }

            movieRepository.SaveStatusToBase();
        }
        
        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        public IEnumerable<Movie> GetAllMovies(MoviesFilter filter)
        {
            IEnumerable<Movie> movies = movieRepository.GetAllMovies(filter);

            return movies;
        }

        /// <summary>
        /// Gets certain movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        public Movie GetMovie (Guid id)
        {
            return movieRepository.GetMovie(id);
        }

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        public void NewMovie(Movie movie)
        {
            movieRepository.NewMovie(movie);
        }

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        public void DeleteMovie (Guid id)
        {
            movieRepository.DeleteMovie(id);
        }

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        public IEnumerable<Status> GetMovieStatuses()
        {
            return movieRepository.GetMovieStatuses().ToList();
        }
              
        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        public IEnumerable<Category> GetMovieCategories()
        {
            return movieRepository.GetMovieCategories().ToList();
        }

        #endregion
    }
}
