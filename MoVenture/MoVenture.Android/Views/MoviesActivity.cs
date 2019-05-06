using System;
using Android.App;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MoVenture.ViewModels;
using MoVenture.Models;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;

namespace MoVenture.Android.Views
{
    [Activity]
    public class MoviesActivity : BaseActivity
    {
    
        public new MoviesViewModel ViewModel
        {
            get { return (MoviesViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_movies);

            var MoviesRecyclerView = FindViewById<MvxRecyclerView>(Resource.Id.rv_movies);

            MoviesRecyclerView.SetLayoutManager(new LinearLayoutManager(this, RecyclerView.Horizontal, false));
            MoviesRecyclerView.Adapter = new CustomMovieAdapter((IMvxAndroidBindingContext)BindingContext, OnRowClicked, ViewModel.Movies);

            SnapHelper helper = new PagerSnapHelper();
            helper.AttachToRecyclerView(MoviesRecyclerView);
        }

        public void OnRowClicked(int row)
        {
            var movie = ViewModel.Movies[row];
            ViewModel.ViewDetailsCommand.Execute(movie);
        }
    }

    public class CustomMovieAdapter : MvxRecyclerAdapter
    {
        public Action<int> OnRowClicked { get; set; }
        private readonly List<Movie> allMovies;

        public CustomMovieAdapter(IMvxAndroidBindingContext bindingContext, Action<int> onRowClicked, IEnumerable<Movie> allMovies)
            : base(bindingContext)
        {
            this.allMovies = allMovies.ToList();
            OnRowClicked = onRowClicked;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            base.OnCreateViewHolder(parent, viewType);

            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new CustomMoviesViewHolder(view, itemBindingContext)
            {
                Click = ItemClick
            };
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            var castedHolder = holder as CustomMoviesViewHolder;
            if (castedHolder == null)
            {
                return;
            }

            var m = allMovies[position];

            castedHolder.MoviePosterImageView.ClipToOutline = true;


            castedHolder.Container.Tag = position;
            try
            {
                castedHolder.Container.Click -= Container_Click;
            }
            catch (Exception e)
            {
            }
            castedHolder.Container.Click+=Container_Click;
        }

        void Container_Click(object sender, EventArgs e)
        {
            var view = sender as View;
            if (view == null)
            {
                return;
            }

            var position = Convert.ToInt32(view.Tag);
            OnRowClicked?.Invoke(position);
        }
    }

    public class CustomMoviesViewHolder : MvxRecyclerViewHolder
    {
        public TextView MovieNameTextView;
        public ImageView MoviePosterImageView;
        public View Container;

        public CustomMoviesViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            Container = itemView;
            MovieNameTextView = itemView.FindViewById<TextView>(Resource.Id.tv_movie_title);
            MoviePosterImageView = itemView.FindViewById<ImageView>(Resource.Id.iv_movie_image);
            var card = itemView.FindViewById<CardView>(Resource.Id.cv_movie_container);
                // MovieCategoriesTextView = itemView.FindViewById<TextView>(Resource.Id.tv_movie_categories);
        }
    }
}