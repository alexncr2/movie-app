using MoVenture.Interfaces;
using MoVenture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoVenture.Services
{
    public class MovieService : IMovieService
    {
        private static IEnumerable<Movie> allMovies;

        public MovieService()
        {
            if (allMovies != null)
            {
                return;
            }
            allMovies = new List<Movie>
            {
                new Movie("pulp fiction", 5f, "movie about two detectives and a boxer and something",
                    new List<Category>{ new Category("Action"), new Category("Drama") }),
                new Movie("Die Hard", 3.96f, "just one cop stopping german bad guy", null),
                new Movie("Blade Runner", 4.30f, "haven't seen it yet, but this description is long i don't know what to say anymore help",
                    new List<Category>{ new Category("Science Fiction") }),
                new Movie("Super Long Movie Title idk something that has a long name", 4.52f, "i made this up lol", null),
                new Movie("Shawshank Redemption", 4.9f, "great movie", null),
                new Movie("Breaking Bad", 5f, "best show of all time", null),
                new Movie("How I Met Your Mother", 3.1f, "comedy stuff", null)
            };
        }

        public Movie Get(Guid movieId)
        {
            var movies = GetMovies(true);
            if (movies != null && movies.Any())
            {
                return movies.FirstOrDefault(movie => movie.Id == movieId);
            }
            throw new Exception("Movie does not exist");
        }

        public IEnumerable<Movie> GetMovies(bool useCache = false)
        {
            return allMovies;
        }
    }
}
