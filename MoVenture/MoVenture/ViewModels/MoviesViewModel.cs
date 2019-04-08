using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class MoviesViewModel : MvxViewModel
    {
        private ObservableCollection<Movie> mMovies = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> mMoviesCopy = new ObservableCollection<Movie>();
        
        private ICommand mViewDetailsCommand;

        public MoviesViewModel()
        {
        }

        public ObservableCollection<Movie> Movies
        {
            get { return mMovies; }
            set { SetProperty(ref mMovies, value); }
        }

        public ICommand ViewDetailsCommand
        {
            get
            {
                if (mViewDetailsCommand == null)
                {
                    mViewDetailsCommand = new MvxCommand<Movie>(ViewDetails);
                }
                return mViewDetailsCommand;
            }
        }

        public override void Start()
        {
            base.Start();

            Movies.Add(new Movie("Pulp Fiction", 5.0));
            Movies.Add(new Movie("Die Hard", 3.96));
            Movies.Add(new Movie("Blade Runner", 4.30));
            Movies.Add(new Movie("Super Long Movie Title idk something that has a long name", 4.52));
            Movies.Add(new Movie("Shawshank Redemption", 4.9));
            Movies.Add(new Movie("Breaking Bad", 5));
            Movies.Add(new Movie("How I Met Your Mother", 3.1));

            mMoviesCopy = mMovies;
        }

        private void ViewDetails(Movie movie)
        {
            ShowViewModel<MovieViewModel>(new { MovieId = movie.Id });
        }
    }
}
