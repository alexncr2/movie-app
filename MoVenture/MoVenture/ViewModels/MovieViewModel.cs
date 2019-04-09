using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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


        public ICommand AddCommentCommand
        {
            get
            {
                return new MvxCommand(AddComment);
            }
        }

        private void AddComment()
        {
            ShowViewModel<CommentViewModel>();
            return;
        }


        public ICommand EditCommentCommand
        {
            get
            {
                return new MvxCommand(EditComment);
            }
        }

        private void EditComment()
        {
            // ShowViewModel<CommentViewModel>();
            return;
        }

        public ICommand DeleteCommentCommand
        {
            get
            {
                return new MvxCommand(DeleteComment);
            }
        }

        private void DeleteComment()
        {
            return;
        }
        
    }
}
