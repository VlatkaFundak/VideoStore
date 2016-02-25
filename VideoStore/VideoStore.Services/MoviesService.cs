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
        public async Task RentMovie(Guid id)
        {
            Movie movie =await movieRepository.GetMovieAsync(id);
            var listOfStatuses = await movieRepository.GetMovieStatusesAsync();
            movie.DateExpired = DateTime.Now.AddDays(7);

            movie.StatusId = listOfStatuses.Where(item => item.Name == "Rented").First().Id;
            await movieRepository.SaveStatusToBase();
        }

        /// <summary>
        /// Returns movie.
        /// </summary>
        /// <param name="id">Id.</param>
        public async Task ReturnMovie (Guid id)
        {
            Movie movie = await movieRepository.GetMovieAsync(id);
            var listOfStatuses = await movieRepository.GetMovieStatusesAsync();

            movie.StatusId = listOfStatuses.Where(item => item.Name == "Available").First().Id;
            movie.DateExpired = null;
            await movieRepository.SaveStatusToBase();
        }
        
        /// <summary>
        /// Changes movie status.
        /// </summary>
        /// <param name="movies">Movies.</param>
        public async Task MoviesChangedStatus(IEnumerable<Movie> movies)
        {
            var listOfStatuses = await movieRepository.GetMovieStatusesAsync();

            foreach (var item in movies)
            {
                if (item.DateExpired <= DateTime.Now)
                {
                    item.StatusId = listOfStatuses.Where(model => model.Name == "Rented(exp)!").First().Id;
                }
            }

            await movieRepository.SaveStatusToBase();
        }
        
        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync(MoviesFilter filter)
        {
            return await movieRepository.GetAllMoviesAsync(filter); 
        }

        /// <summary>
        /// Gets certain movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        public async Task<Movie> GetMovieAsync (Guid id)
        {
            return await movieRepository.GetMovieAsync(id);
        }

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        public async Task NewMovieAsync(Movie movie)
        {
            await movieRepository.NewMovieAsync(movie);
        }

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        public async Task DeleteMovieAsync (Guid id)
        {
            await movieRepository.DeleteMovieAsync(id);
        }

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        public async Task<IEnumerable<Status>> GetMovieStatuses()
        {
            return await movieRepository.GetMovieStatusesAsync();
        }
              
        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        public async Task<IEnumerable<Category>> GetMovieCategories()
        {
            return await movieRepository.GetMovieCategoriesAsync();
        }

        #endregion
    }
}
