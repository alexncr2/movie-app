
using Android.OS;
using Android.Views;
using MoVenture.Android.Application;
using MvvmCross.Droid.Support.V7.AppCompat;
using System;

namespace MoVenture.Android.Views
{
    public class BaseActivity : MvxAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                // ActionBar.Hide();
                CustomApplication.Instance.CurrentActivity = this;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("BaseActivity\n" + e.ToString());
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            CustomApplication.Instance.CurrentActivity = this;
        }
    }
}