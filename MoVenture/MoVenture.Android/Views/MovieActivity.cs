using System.Collections.Generic;
using Android.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using MoVenture.Android.Views.fragments;
using MoVenture.Models;
using MoVenture.ViewModels;
using static MoVenture.Android.MvxFragmentPagerAdapter;

namespace MoVenture.Android.Views
{
    [Activity]
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

            var TabLayoutMovieOptions = FindViewById<TabLayout>(Resource.Id.tl_movie_menu);
            var ViewPagerOptionContent = FindViewById<ViewPager>(Resource.Id.vp_menu_content);

            List<Actor> testActors = new List<Actor>
            {
                new Actor("Tony", "Stark"),
                new Actor("Peter", "Parker"),
                new Actor("Black", "Widow"),
                new Actor("Steve", "Rogers"),
                new Actor("Stan", "Lee")
            };

            List<Comment> testComments = new List<Comment>
            {
                new Comment("Nice movie"),
                new Comment("Bad movie"),
                new Comment("pretty good movie recommand 5/7"),
                new Comment("is ok")
            };

            ViewModel.Movie.Actors = testActors;
            ViewModel.Movie.Comments = testComments;

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
