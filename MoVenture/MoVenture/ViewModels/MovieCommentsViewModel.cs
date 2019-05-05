using MoVenture.Interfaces;
using MoVenture.Models;
using MoVenture.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class MovieCommentsViewModel: MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private ObservableCollection<Comment> mComments;
        private string mError;


        public MovieCommentsViewModel(IMovieService movieService)
        {
            this.mMovieService = movieService;
            mComments = new ObservableCollection<Comment>();
        }

        public ObservableCollection<Comment> Comments
        {
            get { return mComments; }
            set { SetProperty(ref mComments, value); }
        }

        public string ErrorInfo
        {
            get { return mError; }
            set { SetProperty(ref mError, value); }
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            var bundleDictionary = parameters.Data;
            var mId = bundleDictionary["movieId"];

            var movie = mMovieService.Get(Guid.Parse(mId));
            foreach (var a in movie.Comments)
            {
                Comments.Add(a);
            }

            if (Comments.Count == 0)
            {
                ErrorInfo = "No comments for this movie";
            }

        }



        public ICommand AddCommentCommand
        {
            get
            {
                return new MvxCommand(AddComment);
            }
        }

        public ICommand EditCommentCommand
        {
            get
            {
                return new MvxCommand(EditComment);
            }
        }

        public ICommand DeleteCommentCommand
        {
            get
            {
                return new MvxCommand(DeleteComment);
            }
        }



        private void AddComment()
        {
            ShowViewModel<CommentViewModel>();
            return;
        }

        private void EditComment()
        {
            // ShowViewModel<CommentViewModel>();
            return;
        }

        private void DeleteComment()
        {
            return;
        }
    }
}
