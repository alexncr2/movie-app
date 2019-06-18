using MoVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoVenture.Interfaces
{
    public interface IMovieService
    {
        Task<List<MinifiedMovie>> GetMovies(bool useCache);
        List<Movie> GetMoviesBackupFile(bool useCache);
        Movie Get(Guid movieId);
    }
}
