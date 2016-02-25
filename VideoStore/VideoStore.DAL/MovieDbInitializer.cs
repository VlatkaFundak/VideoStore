using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using System.Data.Entity;

namespace VideoStore.DAL
{
    public class MovieDbInitializer : DropCreateDatabaseIfModelChanges<MovieContext>
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

            for (int i = 0; i < 10; i++)
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

                var PulpFiction = new Movie();
                PulpFiction.Id = Guid.NewGuid();
                PulpFiction.Title = "Pulp Fiction";
                PulpFiction.Description = "The lives of two mob hit men, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.";
                PulpFiction.Rating = 8.9;
                PulpFiction.Year = 1994;
                PulpFiction.ImageUrl = "http://pmd205465tn.download.theplatform.com.edgesuite.net/Miramax/137/2/thumbnail_poster_color-PulpFiction_11r2_Approved_640x360_141767235537.jpg";
                PulpFiction.DateCreated = DateTime.Now;
                PulpFiction.DateUpdated = DateTime.Now;
                PulpFiction.CategoryId = Action.Id;
                PulpFiction.StatusId = Available.Id;
                context.Movies.Add(PulpFiction);

                var Matrix = new Movie();
                Matrix.Id = Guid.NewGuid();
                Matrix.Title = "The Matrix";
                Matrix.Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.";
                Matrix.Rating = 8.7;
                Matrix.Year = 1999;
                Matrix.ImageUrl = "https://40.media.tumblr.com/3e61f7caf3067da6f9b3fc405c65f7cf/tumblr_ngn0ui6m1B1u1qk9to1_400.jpg";
                Matrix.DateCreated = DateTime.Now;
                Matrix.DateUpdated = DateTime.Now;
                Matrix.CategoryId = Action.Id;
                Matrix.StatusId = Available.Id;
                context.Movies.Add(Matrix);

                var Cabin = new Movie();
                Cabin.Id = Guid.NewGuid();
                Cabin.Title = "The Cabin in the Woods";
                Cabin.Description = "Five friends go for a break at a remote cabin in the woods, where they get more than they bargained for. Together, they must discover the truth behind the cabin in the woods.";
                Cabin.Rating = 7;
                Cabin.Year = 2012;
                Cabin.ImageUrl = "http://ia.media-imdb.com/images/M/MV5BNTUxNzYyMjg2N15BMl5BanBnXkFtZTcwMTExNzExNw@@._V1_SX640_SY720_.jpg";
                Cabin.DateCreated = DateTime.Now;
                Cabin.DateUpdated = DateTime.Now;
                Cabin.CategoryId = Horror.Id;
                Cabin.StatusId = Rented_exp.Id;
                context.Movies.Add(Cabin);

                var Batman = new Movie();
                Batman.Id = Guid.NewGuid();
                Batman.Title = "Batman Begins";
                Batman.Description = "Five friends go for a break at a remote cabin in the woods, where they get more than they bargained for. Together, they must discover the truth behind the cabin in the woods.";
                Batman.Rating = 8.3;
                Batman.Year = 2005;
                Batman.ImageUrl = "http://vignette4.wikia.nocookie.net/batman/images/1/1e/Batman_Begins_poster6.jpg/revision/latest?cb=20111218145155";
                Batman.DateCreated = DateTime.Now;
                Batman.DateUpdated = DateTime.Now;
                Batman.CategoryId = Action.Id;
                Batman.StatusId = Rented_exp.Id;
                context.Movies.Add(Batman);

                var Deadpool = new Movie();
                Deadpool.Id = Guid.NewGuid();
                Deadpool.Title = "Deadpool";
                Deadpool.Description = "A former Special Forces operative turned mercenary is subjected to a rogue experiment that leaves him with accelerated healing powers, adopting the alter ego Deadpool.";
                Deadpool.Rating = 8.6;
                Deadpool.Year = 2016;
                Deadpool.ImageUrl = "http://slike.blitz-cinestar.hr/filmovi/Deadpool/deadpool%20(11).jpg?width=800";
                Deadpool.DateCreated = DateTime.Now;
                Deadpool.DateUpdated = DateTime.Now;
                Deadpool.CategoryId = Comedy.Id;
                Deadpool.StatusId = Rented.Id;
                context.Movies.Add(Deadpool);
            }

            base.Seed(context);
        }

    }
}
