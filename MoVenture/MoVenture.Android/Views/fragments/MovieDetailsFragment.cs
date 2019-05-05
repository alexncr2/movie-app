using Android.OS;
using Android.Runtime;
using Android.Views;
using MoVenture.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;

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

            return rootView;
        }
    }

}