using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(Label = "CommentActivity")]
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
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}