using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models
{
    /// <summary>
    /// Category class.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
    }
}
