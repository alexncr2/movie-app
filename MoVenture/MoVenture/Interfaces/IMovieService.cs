using MoVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies(bool useCache);
        Movie Get(Guid movieId);
    }
}
