using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace MoVenture.ViewModels
{
    public class MovieViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private Movie mMovie;
        private Guid mMovieId;
        private List<Actor> mActors;
        private List<Comment> mComments;

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

        public List<Comment> Comments
        {
            get { return mComments; }
            set { SetProperty(ref mComments, value); }
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
            Comments = Movie.Comments;
        }

        
        
    }
}
