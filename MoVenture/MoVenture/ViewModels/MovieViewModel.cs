using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class MovieViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private ICommand mBackToMovies;

        private Movie mMovie;
        private Guid mMovieId;

        public MovieViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
        }

        public Movie Movie
        {
            get { return mMovie; }
            set { mMovie = value; RaisePropertyChanged(() => Movie); }
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
            Movie = mMovieService.Get(movieId);
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
