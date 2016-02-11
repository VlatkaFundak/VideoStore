using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;

namespace VideoStore.DAL
{
    /// <summary>
    /// MovieCotext class.
    /// </summary>
    public class MovieContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MovieContext()
            :base("VideoStoreDb")
        {
            Database.SetInitializer<MovieContext>(new MovieDbInitializer());
        }

        /// <summary>
        /// Movies.
        /// </summary>
        public virtual DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Categories.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Statuses.
        /// </summary>
        public virtual DbSet<Status> Statuses { get; set; }
    }
}
