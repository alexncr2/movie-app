using MoVenture.Models;
using MoVenture.Interfaces;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        private ICommand mAddMovieCommand;

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

        public ICommand AddMovieCommand
        {
            get
            {
                mAddMovieCommand = mAddMovieCommand ?? new MvxCommand(AddMovieDetails);
                return mAddMovieCommand;
            }
        }

        public override void Start()
        {
            base.Start();

            //Task.Run(async () => await mMovieService.GetMovies(false).ConfigureAwait(false)).ConfigureAwait(false);
            // Task.Run(async () => await GetData().ConfigureAwait(false)).ConfigureAwait(false);

            // Movies = new ObservableCollection<MinifiedMovie>(MovieHelper.MinMovies);
            Movies = new ObservableCollection<Movie>(mMovieService.GetMoviesBackupFile(false));
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

        private void AddMovieDetails()
        {
            ShowViewModel<AddMovieViewModel>();
        }
        
    }
}
