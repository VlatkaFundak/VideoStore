using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Common.Filters
{
    /// <summary>
    /// Movies filter.
    /// </summary>
    public class MoviesFilter
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="ordering">Ordering.</param>
        /// <param name="searchMovie">Search movie.</param>
        /// <param name="movieStatusId">Movie status id.</param>
        public MoviesFilter(int pageNumber, int pageSize, string ordering, string searchMovie, Guid? movieStatusId, Guid? movieCategoryId)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Ordering = ordering;
            this.SearchMovie = searchMovie;
            this.MovieStatusId = movieStatusId.HasValue ? movieStatusId.Value : Guid.Empty;
            this.MovieCategoryId = movieCategoryId.HasValue ? movieCategoryId.Value : Guid.Empty;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Ordering.
        /// </summary>
        public string Ordering { get; set; }

        /// <summary>
        /// Searching string.
        /// </summary>
        public string SearchMovie { get; set; }

        /// <summary>
        /// Movie status.
        /// </summary>
        public Guid MovieStatusId { get; set; }

        /// <summary>
        /// Movie category.
        /// </summary>
        public Guid MovieCategoryId { get; set; }

        #endregion
    }
}
