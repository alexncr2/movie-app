using System.Collections.Generic;
using Android.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Widget;
using MoVenture.Android.Views.fragments;
using MoVenture.Models;
using MoVenture.ViewModels;
using static MoVenture.Android.MvxFragmentPagerAdapter;

namespace MoVenture.Android.Views
{
    [Activity(Theme = "@style/MainTheme.Base")]
    public class MovieActivity : BaseActivity
    {
        public new MovieViewModel ViewModel
        {
            get { return (MovieViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_movie);

            var toolbarTitle = FindViewById<TextView>(Resource.Id.toolbar_title);
            toolbarTitle.Text = "Movie Details";

            var TabLayoutMovieOptions = FindViewById<TabLayout>(Resource.Id.tl_movie_menu);
            var ViewPagerOptionContent = FindViewById<ViewPager>(Resource.Id.vp_menu_content);
            

            ViewPagerOptionContent.Adapter = new MvxFragmentPagerAdapter(this, SupportFragmentManager,
                new List<FragmentInfo>
            {
                    new FragmentInfo("Details", typeof(MovieDetailsFragment), typeof(MovieDetailsViewModel)),
                    new FragmentInfo("Comments", typeof(MovieCommentsFragment), typeof(MovieCommentsViewModel)),
                    new FragmentInfo("Actors", typeof(MovieActorsFragment), typeof(MovieActorsViewModel)),
            }, ViewModel.Movie.Id);

            TabLayoutMovieOptions.SetupWithViewPager(ViewPagerOptionContent);
        }
        
    }
}
