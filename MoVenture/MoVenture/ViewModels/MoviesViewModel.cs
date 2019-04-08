using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class MoviesViewModel : MvxViewModel
    {
        private ObservableCollection<Movie> mMovies;
        private ObservableCollection<Movie> mMoviesCopy;

        private readonly IMovieService mMovieService;
        private ICommand mViewDetailsCommand;

        public MoviesViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
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

            Movies = new ObservableCollection<Movie>(mMovieService.GetMovies(true));
            mMoviesCopy = Movies;
        }

        private void ViewDetails(Movie movie)
        {
            ShowViewModel<MovieViewModel>(new { movieId = movie.Id });
        }
    }
}
