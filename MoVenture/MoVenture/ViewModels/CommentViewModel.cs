using MoVenture.Models;
using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class CommentViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;
        
        private string mCommentMessage;
        private float mRating;
        public Action OnCancel { get; set; }

        public CommentViewModel()
        {
        }

        public string CommentMessage
        {
            get { return mCommentMessage; }
            set { mCommentMessage = value; RaisePropertyChanged(() => CommentMessage); }
        }

        public float Rating
        {
            get { return mRating; }
            set { mRating = value; RaisePropertyChanged(() => Rating); }
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
            // ShowViewModel<MovieCommentsViewModel>(new Comment(Rating, CommentMessage));
            Close(this);
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
            Close(this);
            // OnCancel?.Invoke();
        }
    }
}
