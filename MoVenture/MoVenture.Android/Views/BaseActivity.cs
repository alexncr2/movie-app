
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
            try
            {
                base.OnCreate(savedInstanceState);
                CustomApplication.Instance.CurrentActivity = this;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print("why" + e.InnerException.ToString());
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}