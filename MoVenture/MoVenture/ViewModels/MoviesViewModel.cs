using MoVenture.Interfaces;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class MoviesViewModel : MvxViewModel
    {
        private readonly IMovieService mMovieService;

        private ObservableCollection<Movie> mMovies;
        private ObservableCollection<Movie> mMoviesCopy;
        private string mSearchTerm;

        private ICommand mViewDetailsCommand;
        private ICommand mFilterCommand;

        public MoviesViewModel(IMovieService movieService)
        {
            mMovieService = movieService;
        }

        public ObservableCollection<Movie> Movies
        {
            get { return mMovies; }
            set { SetProperty(ref mMovies, value); }
        }

        public string SearchTerm
        {
            get { return mSearchTerm; }
            set { mSearchTerm = value; RaisePropertyChanged(() => SearchTerm); }
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

        public ICommand FilterCommand
        {
            get
            {
                mFilterCommand = mFilterCommand ?? new MvxCommand(FilterResults);
                return mFilterCommand;
            }
        }

        public override void Start()
        {
            base.Start();


            List<Movie> dbMovies = mMovieService.GetMovies(true).ToList();

            Movies = new ObservableCollection<Movie>(dbMovies);
            mMoviesCopy = mMovies;
        }



        private void ViewDetails(Movie movie)
        {
            ShowViewModel<MovieViewModel>(new { movieId = movie.Id });
        }

        private void FilterResults()
        {
            if (!string.IsNullOrWhiteSpace(mSearchTerm))
            {
                var filteredFriends = Movies.Where(fr => fr.Title.ToLower().Contains(mSearchTerm.ToLower())).ToList();
                Movies = new ObservableCollection<Movie>(filteredFriends);
            }
            else
            {
                Movies = mMoviesCopy;
            }
        }
    }
}
