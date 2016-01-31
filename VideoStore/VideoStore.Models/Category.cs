using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models.Common;

namespace VideoStore.Models
{
    /// <summary>
    /// Category class.
    /// </summary>
    public class Category: ICategory
    {
        #region Properties

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
