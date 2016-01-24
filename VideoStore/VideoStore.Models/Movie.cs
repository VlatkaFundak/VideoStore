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
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Category Id.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Status Id.
        /// </summary>
        public Guid StatusId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Rating.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public virtual Status Status { get; set; }
    }
}
