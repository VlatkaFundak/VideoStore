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

        //TODO: status ručno napisan, obrisati naknadno
        public Guid AvailableStatus()
        {
            var Available = new Status();
            Available.Id = Guid.NewGuid();
            Available.Name = "Available";
            MovieContext.Statuses.Add(Available);
            return (Available.Id);
        }

        //TODO: status ručno napisan, obrisati naknadno
        public Guid RentedStatus()
        {
            var Rented = new Status();
            Rented.Id = Guid.NewGuid();
            Rented.Name = "Rented";
            MovieContext.Statuses.Add(Rented);
            return(Rented.Id);
        }

        //TODO: status ručno napisan, obrisati naknadno
        public Guid ExpiredRent()
        {
            var expiredRent = new Status();
            expiredRent.Id = Guid.NewGuid();
            expiredRent.Name = "Rented(exp)!";
            MovieContext.Statuses.Add(expiredRent);
            return (expiredRent.Id);
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
            Meet_The_Millers.ImageUrl = "https://ireckonthat.files.wordpress.com/2014/03/were-the-millers2.jpg";
            Meet_The_Millers.DateCreated = DateTime.Now;
            Meet_The_Millers.DateUpdated = DateTime.Now;
            Meet_The_Millers.CategoryId = Comedy.Id;
            Meet_The_Millers.StatusId = AvailableStatus();
            MovieContext.Movies.Add(Meet_The_Millers);

            var Minions = new Movie();
            Minions.Id = Guid.NewGuid();
            Minions.Title = "Minions";
            Minions.Description = "Animated";
            Minions.Rating = 7.1;
            Minions.Year = 2015;
            Minions.ImageUrl = "http://blogs-images.forbes.com/dorothypomerantz/files/2015/07/minions_2015-wide.jpg";
            Minions.DateCreated = DateTime.Now;
            Minions.DateUpdated = DateTime.Now;
            Minions.CategoryId = Action.Id;
            Minions.StatusId = AvailableStatus();
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
