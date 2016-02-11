using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.DAL;
using VideoStore.Models;
using VideoStore.Repository.Common;

namespace VideoStore.Repository
{
    /// <summary>
    /// Movies repository class.
    /// </summary>
    public class MoviesRepository: IMoviesRepository
    {
        #region Fields

        /// <summary>
        /// Gets or sets movie context.
        /// </summary>
        private MovieContext MovieContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MoviesRepository()
        {
            MovieContext = new MovieContext();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            return (MovieContext.Movies);
        }

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        public IEnumerable<Status> GetMovieStatuses()
        {
            return (MovieContext.Statuses);
        }

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        public void NewMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            movie.StatusId = MovieContext.Statuses.Where(item => String.Equals(item.Name, "Available")).First().Id;
            movie.DateCreated = DateTime.Now;
            movie.DateUpdated = DateTime.Now;

            MovieContext.Movies.Add(movie);
            MovieContext.SaveChanges();
        }

        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        public IEnumerable<Category> GetMovieCategories()
        {
            return MovieContext.Categories.ToList();
        }

        /// <summary>
        /// Gets chosen movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        public Movie GetMovie(Guid id)
        {
            var selectedMovie = MovieContext.Movies.ToList().Find(item => item.Id == id);

            return (selectedMovie);
        }

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        public void DeleteMovie(Guid id)
        {
            MovieContext.Movies.Remove(GetMovie(id));
            MovieContext.SaveChanges();
        }

        /// <summary>
        /// Saves data to base.
        /// </summary>
        public void SaveStatusToBase()
        {
            MovieContext.SaveChanges();
        }

        #endregion

    }
}
