using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Widget;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(Label = "CommentActivity", Theme = "@style/MainTheme.Base")]
    public class CommentActivity : BaseActivity
    {
        public new CommentViewModel ViewModel
        {
            get { return (CommentViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_comments);
            ViewModel.OnCancel = OnBackPressed;


            RatingBar ratingbar = FindViewById<RatingBar>(Resource.Id.rb_user_rating);

            ratingbar.RatingBarChange += (o, e) => {
                // Toast.MakeText(this, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
                ViewModel.Rating = ratingbar.Rating;
            };

            
        }
        
    }
}