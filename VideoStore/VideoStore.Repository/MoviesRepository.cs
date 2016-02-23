using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.DAL;
using VideoStore.Models;
using VideoStore.Repository.Common;
using VideoStore.Common.Filters;
using System.Linq.Dynamic;

using PagedList;
using PagedList.Mvc;
using PagedList.EntityFramework;

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
        /// Gets certain movie.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Movie.</returns>
        public async Task<Movie> GetMovieAsync(Guid id)
        {
            try
            {
                return await MovieContext.Movies.FindAsync(id);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <param name="filter">Movie filter.</param>
        /// <returns>Gets collection of all movies.</returns>
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync(MoviesFilter filter)
        {
            try
            {
               return await MovieContext.Movies
                    .Where(item => String.IsNullOrEmpty(filter.SearchMovie) ? item != null : item.Title.Contains(filter.SearchMovie))
                    .Where(item => Guid.Empty == filter.MovieStatusId ? item != null : item.StatusId == filter.MovieStatusId)
                    .Where(item => Guid.Empty == filter.MovieCategoryId ? item != null : item.CategoryId == filter.MovieCategoryId)
                    .OrderBy(filter.Ordering)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);
            }

            catch (Exception e)
            {                
                throw e;
            }
        }

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        public async Task NewMovieAsync(Movie movie)
        {
            movie.Id = Guid.NewGuid();

            try
            {
                movie.StatusId = MovieContext.Statuses.First(item => String.Equals(item.Name, "Available")).Id;
                movie.DateCreated = DateTime.Now;
                movie.DateUpdated = DateTime.Now;

                MovieContext.Movies.Add(movie);
                await MovieContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        
        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        public async Task DeleteMovieAsync(Guid id)
        {
            try
            {
                Movie removeMovie = await MovieContext.Movies.FindAsync(id);
                MovieContext.Movies.Remove(removeMovie);
                await MovieContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        /// <summary>
        /// Saves data to base.
        /// </summary>
        public async Task SaveStatusToBase()
        {
            try
            {
                await MovieContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>Statuses.</returns>
        public async Task<IEnumerable<Status>> GetMovieStatusesAsync()
        {
            return await MovieContext.Statuses.ToListAsync();
        }

        /// <summary>
        /// Gets movie categories.
        /// </summary>
        /// <returns>Categories.</returns>
        public async Task<IEnumerable<Category>> GetMovieCategoriesAsync()
        {
            return await MovieContext.Categories.ToListAsync();
        }

        #endregion

    }
}
