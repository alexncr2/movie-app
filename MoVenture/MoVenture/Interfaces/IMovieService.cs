using MoVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoVenture.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies(bool useCache);
        Movie Get(Guid movieId);
    }
}
