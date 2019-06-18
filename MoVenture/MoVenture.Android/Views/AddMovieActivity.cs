using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(Theme = "@style/MainTheme.Base")]
    public class AddMovieActivity : BaseActivity
    {
        public new AddMovieViewModel ViewModel
        {
            get { return (AddMovieViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_add_movie);

        }


    }
}