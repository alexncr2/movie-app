using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class AddMovieViewModel : MvxViewModel
    {
        private string mTitle;
        private string mDescription;
        private string mPictureUrl;
        private string mTrailerUrl;
        private ObservableCollection<ActorModel> mActors;
        private ObservableCollection<CategoryModel> mCategories;
        private ICommand mSaveMovieCommand;
        private ICommand mBackToMovies;

        public AddMovieViewModel()
        {

        }

        public string Title
        {
            get { return mTitle; }
            set { mTitle = value; RaisePropertyChanged(() => Title); }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; RaisePropertyChanged(() => Description); }
        }

        public string Picture
        {
            get { return mPictureUrl; }
            set { mPictureUrl = value; RaisePropertyChanged(() => Picture); }
        }

        public string Trailer
        {
            get { return mTrailerUrl; }
            set { mTrailerUrl = value; RaisePropertyChanged(() => Trailer); }
        }

        public ObservableCollection<ActorModel> Actors
        {
            get { return mActors; }
            set { SetProperty(ref mActors, value); }
        }

        public ObservableCollection<CategoryModel> Categories
        {
            get { return mCategories; }
            set { SetProperty(ref mCategories, value); }
        }

        public ICommand AddMovieGoBackCommand
        {
            get
            {
                mBackToMovies = mBackToMovies ?? new MvxCommand(GoBackToMovies);
                return mBackToMovies;
            }
        }

        public ICommand SaveMovie
        {
            get
            {
                if (mSaveMovieCommand == null)
                {
                    mSaveMovieCommand = new MvxCommand(SaveMovieToDatabase);
                }
                return mSaveMovieCommand;
            }
        }

        private void SaveMovieToDatabase()
        {

        }

        private void GoBackToMovies()
        {
            Close(this);
        }
    }
}
