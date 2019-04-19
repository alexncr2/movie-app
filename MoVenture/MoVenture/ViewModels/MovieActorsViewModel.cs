using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.ViewModels
{
    public class MovieActorsViewModel : MvxViewModel
    {
        private List<Actor> mActors;
        private string mError;

        public List<Actor> Actors
        {
            get { return mActors; }
            set { SetProperty(ref mActors, value); }
        }

        public string ErrorInfo
        {
            get { return mError; }
            set { SetProperty(ref mError, value); }
        }


    }
}
