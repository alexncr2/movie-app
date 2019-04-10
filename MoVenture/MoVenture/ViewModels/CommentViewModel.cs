using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class CommentViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private Movie Movie;
        private string mCommentMessage;
        private string mMovieId;


        public CommentViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
        }

        public string CommentMessage
        {
            get { return mCommentMessage; }
            set { mCommentMessage = value; RaisePropertyChanged(() => CommentMessage); }
        }


        public ICommand SaveCommentCommand
        {
            get
            {
                return new MvxCommand(SaveComment);
            }
        }

        private void SaveComment()
        {
            Comment c = new Comment(CommentMessage);
            return;
        }


        public ICommand CancelCommand
        {
            get
            {
                return new MvxCommand<Movie>(Cancel);
            }
        }

        private void Cancel(Movie movie)
        {
            ShowViewModel<MoviesViewModel>();
            return;
        }
    }
}
