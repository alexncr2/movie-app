
using Android.OS;
using MvvmCross.Droid.Views;
using MoVenture.Android.Application;
using Android.App;
using System;
using System.Diagnostics;

namespace MoVenture.Android.Views
{
    public class BaseActivity : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            CustomApplication.Instance.CurrentActivity = this;
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}