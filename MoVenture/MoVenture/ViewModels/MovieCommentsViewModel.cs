using MoVenture.Interfaces;
using MoVenture.Models;
using MoVenture.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class MovieCommentsViewModel: MvxViewModel
    {
        private List<Comment> mComments;
        private string mError;


        public MovieCommentsViewModel()
        {
        }

        public List<Comment> Comments
        {
            get { return mComments; }
            set { SetProperty(ref mComments, value); }
        }

        public string ErrorInfo
        {
            get { return mError; }
            set { SetProperty(ref mError, value); }
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
