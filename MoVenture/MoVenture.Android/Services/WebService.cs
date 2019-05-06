using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MoVenture.Interfaces;

namespace MoVenture.Android.Services
{
    public class WebService : IWebService
    {
        private readonly Context Context;

        public WebService(Context ctx)
        {
            this.Context = ctx;
        }

        public void OpenUrl(string url)
        {
            Uri uri = Uri.Parse(url); 
            Intent webIntent = new Intent(Intent.ActionView, uri);
            webIntent.AddFlags(ActivityFlags.NewTask);

            Context.StartActivity(webIntent);
        }
    }
}