using MoVenture.Models;
using MoVenture.Interfaces;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace MoVenture.ViewModels
{
    public class MovieActorsViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private ObservableCollection<ActorModel> mActors;
        private string mError;

        public MovieActorsViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
            mActors = new ObservableCollection<ActorModel>();
        }

        public ObservableCollection<ActorModel> Actors
        {
            get { return mActors; }
            set { SetProperty(ref mActors, value); }
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
            var mId = bundleDictionary["movie"];

            var movie = JsonConvert.DeserializeObject<Movie>(mId);
            foreach (var a in movie.Actors)
            {
                Actors.Add(a);
            }

            if (Actors.Count == 0)
            {
                ErrorInfo = "No actors for this movie";
            }

        }

    }
}
