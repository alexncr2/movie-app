﻿
using Android.App;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(Theme = "@style/MainTheme.Base")]
    public class RegisterActivity : BaseActivity
    {
        public new RegisterViewModel ViewModel
        {
            get { return (RegisterViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_register);
        }
    }
}