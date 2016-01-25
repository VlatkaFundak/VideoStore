using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.DAL;
using VideoStore.Models;

namespace VideoStore.Repository
{
    public class MoviesRepository
    {
        public void Test()
        {
            var Test = new MovieContext();
            var CategoryObject = new Category();
            CategoryObject.Id = Guid.NewGuid();
            CategoryObject.Name = "Comedy";

            Test.Categories.Add(CategoryObject);
            Test.SaveChanges();

            var StatusObject = new Status();
            StatusObject.Id = Guid.NewGuid();
            StatusObject.Name = "";

            var MovieObject = new Movie();
            MovieObject.Id = Guid.NewGuid();
            MovieObject.Description = "Comedy movie";
            MovieObject.DateCreated = DateTime.Now;
            MovieObject.DateUpdated = DateTime.Now;
            MovieObject.CategoryId = CategoryObject.Id;


        }
    }
}
