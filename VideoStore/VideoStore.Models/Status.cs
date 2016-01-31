﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models.Common;

namespace VideoStore.Models
{
    /// <summary>
    /// Status class.
    /// </summary>
    public class Status: IStatus
    {
        #region Properties

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
