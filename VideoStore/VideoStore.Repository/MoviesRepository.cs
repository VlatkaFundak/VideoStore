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
        /// <summary>
        /// Gets or sets movie context.
        /// </summary>
        private MovieContext MovieContext;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MoviesRepository()
        {
            MovieContext = new MovieContext();
        }
        
        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>Movies.</returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            return (MovieContext.Movies);
        }

        /// <summary>
        /// Creates new movie.
        /// </summary>
        /// <param name="movie">Movie.</param>
        /// <returns>Movie.</returns>
        public void NewMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            movie.Status = NewStatus();
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
            return (MovieContext.Categories.ToList());
        }


        public Status NewStatus()
        {
            var Available = new Status();
            Available.Id = Guid.NewGuid();
            Available.Name = "Available";
            MovieContext.Statuses.Add(Available);
            return (Available);
        }
        //TODO: obrisati naknadno, kreiram ručno objekt tu
        ///<summary>
        ///New movie.
        ///</summary>
        public void NewObject()
        {
            var Action = new Category();
            Action.Id = Guid.NewGuid();
            Action.Name = "Action";
            MovieContext.Categories.Add(Action);

            var Comedy = new Category();
            Comedy.Id = Guid.NewGuid();
            Comedy.Name = "Comedy";
            MovieContext.Categories.Add(Comedy);

            var Horror = new Category();
            Horror.Id = Guid.NewGuid();
            Horror.Name = "Horror";
            MovieContext.Categories.Add(Horror);

            var Available = new Status();
            Available.Id = Guid.NewGuid(); ;
            Available.Name = "Available";
            MovieContext.Statuses.Add(Available);

            var Rented = new Status();
            Rented.Id = Guid.NewGuid();
            Rented.Name = "Rented";
            MovieContext.Statuses.Add(Rented);

            var Rented_exp = new Status();
            Rented_exp.Id = Guid.NewGuid();
            Rented_exp.Name = "Rented(exp)!";
            MovieContext.Statuses.Add(Rented_exp);

            var Meet_The_Millers = new Movie();
            Meet_The_Millers.Id = Guid.NewGuid();
            Meet_The_Millers.Title = "Meet the Millers";
            Meet_The_Millers.Description = "Comedy movie";
            Meet_The_Millers.Rating = 7.9;
            Meet_The_Millers.Year = 2012;
            Meet_The_Millers.DateCreated = DateTime.Now;
            Meet_The_Millers.DateUpdated = DateTime.Now;
            Meet_The_Millers.CategoryId = Comedy.Id;
            Meet_The_Millers.StatusId = Available.Id;
            MovieContext.Movies.Add(Meet_The_Millers);

            var Minions = new Movie();
            Minions.Id = Guid.NewGuid();
            Minions.Title = "Minions";
            Minions.Description = "Animated";
            Minions.Rating = 7.9;
            Minions.Year = 2015;
            Minions.DateCreated = DateTime.Now;
            Minions.DateUpdated = DateTime.Now;
            Minions.CategoryId = Action.Id;
            Minions.StatusId = Available.Id;
            MovieContext.Movies.Add(Minions);

            MovieContext.SaveChanges();
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
            GetMovie(id);
            MovieContext.Movies.Remove(GetMovie(id));
            MovieContext.SaveChanges();
        }
    }
}
