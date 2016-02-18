using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Common.Filters
{
    class MoviesFilter
    {

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public MoviesFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

    }
}
