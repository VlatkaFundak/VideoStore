using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models.Common
{
    /// <summary>
    /// Movie interface.
    /// </summary>
    public interface IMovie
    {
        #region Properties

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets category identifier.
        /// </summary>
        Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets status identifier.
        /// </summary>
        Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets image url.
        /// </summary>
        string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets rating.
        /// </summary>
        double Rating { get; set; }

        /// <summary>
        /// Gets or sets date created.
        /// </summary>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets date updated.
        /// </summary>
        DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets category.
        /// </summary>
        ICategory Category { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        IStatus Status { get; set; }

        #endregion
    }
}
