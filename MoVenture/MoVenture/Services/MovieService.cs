using MoVenture.Interfaces;
using MoVenture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MoVenture.Services
{
    public class MovieService : IMovieService
    {
        private static IEnumerable<Movie> allMovies;

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
            if (useCache && allMovies != null)
            {
                return allMovies;
            }
            
            using (var stream = typeof(MovieService).GetTypeInfo().Assembly.
                       GetManifestResourceStream("MoVenture.Resources.movie_data.json"))
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                allMovies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);
                return allMovies;
            }
        }
    }
}
