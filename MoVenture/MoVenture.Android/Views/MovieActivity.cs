
using Android.App;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(Label = "Movie")]
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
        }
    }
}