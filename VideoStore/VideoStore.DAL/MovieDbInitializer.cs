using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using System.Data.Entity;

namespace VideoStore.DAL
{
    public class MovieDbInitializer: DropCreateDatabaseIfModelChanges<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            var Action = new Category();
            Action.Id = Guid.NewGuid();
            Action.Name = "Action";
            context.Categories.Add(Action);

            var Comedy = new Category();
            Comedy.Id = Guid.NewGuid();
            Comedy.Name = "Comedy";
            context.Categories.Add(Comedy);

            var Horror = new Category();
            Horror.Id = Guid.NewGuid();
            Horror.Name = "Horror";
            context.Categories.Add(Horror);

            var Animated = new Category();
            Animated.Id = Guid.NewGuid();
            Animated.Name = "Animated";
            context.Categories.Add(Animated);

            var Available = new Status();
            Available.Id = Guid.NewGuid(); ;
            Available.Name = "Available";
            context.Statuses.Add(Available);

            var Rented = new Status();
            Rented.Id = Guid.NewGuid();
            Rented.Name = "Rented";
            context.Statuses.Add(Rented);

            var Rented_exp = new Status();
            Rented_exp.Id = Guid.NewGuid();
            Rented_exp.Name = "Rented(exp)!";
            context.Statuses.Add(Rented_exp);

            for (int i = 0; i < 30; i++)
            {
                var Meet_The_Millers = new Movie();
                Meet_The_Millers.Id = Guid.NewGuid();
                Meet_The_Millers.Title = "Meet the Millers";
                Meet_The_Millers.Description = "Comedy movie";
                Meet_The_Millers.Rating = 7.9;
                Meet_The_Millers.Year = 2012;
                Meet_The_Millers.ImageUrl = "https://ireckonthat.files.wordpress.com/2014/03/were-the-millers2.jpg";
                Meet_The_Millers.DateCreated = DateTime.Now;
                Meet_The_Millers.DateUpdated = DateTime.Now;
                Meet_The_Millers.CategoryId = Comedy.Id;
                Meet_The_Millers.StatusId = Available.Id;
                context.Movies.Add(Meet_The_Millers);

                var Minions = new Movie();
                Minions.Id = Guid.NewGuid();
                Minions.Title = "Minions";
                Minions.Description = "Animated";
                Minions.Rating = 7.1;
                Minions.Year = 2015;
                Minions.ImageUrl = "http://blogs-images.forbes.com/dorothypomerantz/files/2015/07/minions_2015-wide.jpg";
                Minions.DateCreated = DateTime.Now;
                Minions.DateUpdated = DateTime.Now;
                Minions.CategoryId = Animated.Id;
                Minions.StatusId = Available.Id;
                context.Movies.Add(Minions);
            }

            base.Seed(context);
        }

    }
}
