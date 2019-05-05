using MoVenture.Interfaces;
using MoVenture.Models;
using MoVenture.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace MoVenture.ViewModels
{
    public class MovieDetailsViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private string mDescription;
        private List<Category> mCategories;

        public MovieDetailsViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; RaisePropertyChanged(() => Description); }
        }

        public List<Category> Categories
        {
            get { return mCategories; }
            set { mCategories = value; RaisePropertyChanged(() => Categories); }
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            var bundleDictionary = parameters.Data;
            var mId = bundleDictionary["movieId"];

            var movie = mMovieService.Get(Guid.Parse(mId));
            Description = movie.Description;
            Categories = movie.Categories;

        }
    }
}
