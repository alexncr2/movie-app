using MoVenture.Models;
using MoVenture.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MoVenture.Services
{
    public class MovieService : IMovieService
    {
        private static List<Movie> allMovies;
        private static List<MinifiedMovie> allMinifiedMovies;

        public Movie Get(Guid movieId)
        {
            var movies = GetMoviesBackupFile(true);
            if (movies != null && movies.Any())
            {
                return movies.FirstOrDefault(movie => movie.Id == movieId);
            }
            throw new Exception("Movie does not exist");
        }


        public async Task<List<MinifiedMovie>> GetMovies(bool useCache = false)
        {
            if (useCache && allMovies != null)
            {
                return allMinifiedMovies;
            }

            var movies =  await HttpClientManager.GetUserMovieData("email@gmail.com");
            allMinifiedMovies = movies;

            return movies;
        }

        public List<Movie> GetMoviesBackupFile(bool useCache = false)
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
                allMovies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(content).ToList();
                return allMovies;
            }
        }
    }
}
