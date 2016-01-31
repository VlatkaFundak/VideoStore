using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models.Common
{
    /// <summary>
    /// Category interface.
    /// </summary>
    public interface ICategory
    {
        #region Properties

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        #endregion
    }
}
