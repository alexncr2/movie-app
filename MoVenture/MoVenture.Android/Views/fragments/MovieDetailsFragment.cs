using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MoVenture.Models;
using MoVenture.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MoVenture.Android.Views.fragments
{
    [Register("moventure.android.views.fragments.MovieDetailsFragment")]
    public class MovieDetailsFragment : MvxFragment<MovieDetailsViewModel>
    {
        public MovieDetailsFragment()
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                  Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var rootView = this.BindingInflate(Resource.Layout.fragment_movie_details, null);

            var castedActivity = Activity as MovieActivity;
            var movie = castedActivity.GetMovie();

            ViewModel.Description = movie.Description;

            return rootView;
        }
    }

}