using MoVenture.Interfaces;
using MoVenture.Models;
using MoVenture.Services;
using MvvmCross.Core.ViewModels;
using System;

namespace MoVenture.ViewModels
{
    public class MovieDetailsViewModel : MvxViewModel
    {

        private string mDescription;

        public MovieDetailsViewModel()
        {
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; RaisePropertyChanged(() => Description); }
        }


    }
}
