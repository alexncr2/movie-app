using MoVenture.Models;
using MoVenture.Interfaces;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using MoVenture.Services;

namespace MoVenture.ViewModels
{
    public class MovieViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;
       

        private ICommand mBackToMovies;

        private Movie mMovie;
        private Guid mMovieId;
        private string mMovieTitle;

        public MovieViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
        }

        public Movie Movie
        {
            get { return mMovie; }
            set { mMovie = value; RaisePropertyChanged(() => Movie); }
        }

        public string MovieTitle
        {
            get { return mMovieTitle; }
            set { mMovieTitle = value; RaisePropertyChanged(() => MovieTitle); }
        }

        public ICommand GoBackCommand
        {
            get
            {
                mBackToMovies = mBackToMovies ?? new MvxCommand(GoBackToMovies);
                return mBackToMovies;
            }
        }

        public void Init(Guid movieId)
        {
            mMovieId = movieId;
            //Movie = mMovieService.Get(movieId);
            Task.Run(async () => await GetDataForMovie(mMovieId).ConfigureAwait(false)).ConfigureAwait(false);
        }

        private async Task GetDataForMovie(Guid id)
        {
            var movie = await HttpClientManager.GetMovieById(id);
            Movie = movie;
            MovieTitle = movie.Title;
        }

        public override void Start()
        {
            base.Start();
        }


        private void GoBackToMovies()
        {
            Close(this);
        }
        
        
    }
}
