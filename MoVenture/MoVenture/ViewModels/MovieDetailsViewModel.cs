using MoVenture.Interfaces;
using MoVenture.Models;
using MoVenture.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class MovieDetailsViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;
        private readonly IWebService mWebService;

        private ICommand mWatchTrailerCommand;

        private string mDescription;
        private string mTrailer;


        public MovieDetailsViewModel(IMovieService movieService, IWebService webService)
        {
            mMovieService = movieService;
            mWebService = webService;
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; RaisePropertyChanged(() => Description); }
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            var bundleDictionary = parameters.Data;
            var mId = bundleDictionary["movieId"];

            var movie = mMovieService.Get(Guid.Parse(mId));
            Description = movie.Description;
            mTrailer = movie.Trailer;
        }

        public ICommand WatchTrailerCommand
        {
            get
            {
                if (mWatchTrailerCommand == null)
                {
                    mWatchTrailerCommand = new MvxCommand(WatchTrailer);
                }
                return mWatchTrailerCommand;
            }
        }

        private void WatchTrailer()
        {
            mWebService.OpenUrl(mTrailer);
        }
    }
}
