using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models.Common
{
    /// <summary>
    /// Status interface.
    /// </summary>
    public interface IStatus
    {
        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        string Name { get; set; }
    }
}
