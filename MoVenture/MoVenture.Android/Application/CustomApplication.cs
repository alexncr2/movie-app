
using System;
using Android.App;
using Android.Runtime;

namespace MoVenture.Android.Application
{
    class CustomApplication : global::Android.App.Application
    {
        private static CustomApplication _instance = null;

        public Activity CurrentActivity { get; set; }

        private CustomApplication()
        {

        }

        public static CustomApplication Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomApplication();
                }
                return _instance;
            }
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
    }
}