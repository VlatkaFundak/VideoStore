using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using VideoStore.Repository;
using VideoStore.Repository.Common;

namespace VideoStore.Services
{
    public class SetMovieStatusToRented
    {
        private IMoviesRepository movieRepository;

        public SetMovieStatusToRented()
        {
            movieRepository = new MoviesRepository();
        }

        public void Rent(Guid id)
        {
            Movie movie = movieRepository.GetMovie(id);
            Guid rented = movieRepository.RentedStatus();

            movie.StatusId = rented;
            movieRepository.SaveStatusToBase();
        }

        public void Exp_Rent (Guid id)
        {

        }
    }
}
