using System;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(Label = "Movies")]
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

            MoviesRecyclerView.SetLayoutManager(new LinearLayoutManager(this, RecyclerView.Vertical, false));
            MoviesRecyclerView.Adapter = new CustomMovieAdapter((IMvxAndroidBindingContext)BindingContext, OnRowClicked);
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

        public CustomMovieAdapter(IMvxAndroidBindingContext bindingContext, Action<int> onRowClicked) : base(bindingContext)
        {
            OnRowClicked = onRowClicked;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            base.OnCreateViewHolder(parent, viewType);

            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new CustomMoviesViewHolder(view, itemBindingContext);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            var castedHolder = holder as CustomMoviesViewHolder;
            if (castedHolder == null)
            {
                return;
            }
        }

        void Container_Click(object sender, EventArgs e)
        {
            #pragma warning disable IDE0019 // Use pattern matching
            var view = sender as View;
            #pragma warning restore IDE0019 // Use pattern matching
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
        public View Container;

        public CustomMoviesViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            Container = itemView;
            MovieNameTextView = itemView.FindViewById<TextView>(Resource.Id.tv_movie_title);
        }
    }
}