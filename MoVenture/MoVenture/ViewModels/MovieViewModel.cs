using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoVenture.ViewModels
{
    public class MovieViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private Movie mMovie;
        private Guid mMovieId;
        private List<Actor> mActors;

        public MovieViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
        }

        public Movie Movie
        {
            get { return mMovie; }
            set { mMovie = value; RaisePropertyChanged(() => Movie); }
        }

        public List<Actor> Actors
        {
            get { return mActors; }
            set { SetProperty(ref mActors, value); }
        }

        public void Init(Guid movieId)
        {
            mMovieId = movieId;
            Movie = mMovieService.Get(movieId);
        }

        public override void Start()
        {
            base.Start();
            Actors = Movie.Actors;
        }


    }
}
