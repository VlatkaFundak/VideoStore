using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models
{
    /// <summary>
    /// Movie model class.
    /// </summary>
    public class Movie
    {
        #region Properties

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets category identifier.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets status identifier.
        /// </summary>
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets image url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets rating.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets category.
        /// </summary>  
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public virtual Status Status { get; set; }

        #endregion
    }
}
