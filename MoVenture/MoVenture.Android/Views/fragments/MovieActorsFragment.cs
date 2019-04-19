using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MoVenture.Models;
using MoVenture.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MoVenture.Android.Views.fragments
{
    [Register("moventure.android.views.fragments.MovieActorsFragment")]
    public class MovieActorsFragment : MvxFragment<MovieActorsViewModel>
    {
        public MovieActorsFragment()
        {

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                  Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var rootView = this.BindingInflate(Resource.Layout.fragment_movie_actors, null);

            var ActorsRecyclerView = rootView.FindViewById<MvxRecyclerView>(Resource.Id.rv_actors_list);

            var castedActivity = Activity as MovieActivity;
            var movie = castedActivity.GetMovie();

            ActorsRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity, RecyclerView.Horizontal, false));
            ActorsRecyclerView.Adapter = new CustomCommentAdapter((IMvxAndroidBindingContext)BindingContext, movie);


            if (ViewModel.Actors == null)
            {
                ViewModel.ErrorInfo = "no actors available";
            }

            return rootView;
        }
    }

    public class CustomActorAdapter : MvxRecyclerAdapter
    {
        private readonly Movie Movie;

        public CustomActorAdapter(IMvxAndroidBindingContext bindingContext, Movie movie) : base(bindingContext)
        {
            this.Movie = movie;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            base.OnCreateViewHolder(parent, viewType);

            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new CustomActorViewHolder(view, itemBindingContext);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            var castedHolder = holder as CustomActorViewHolder;
            if (castedHolder == null)
            {
                return;
            }


        }
    }


    public class CustomActorViewHolder : MvxRecyclerViewHolder
    {
        public TextView ActorNameTextView;
        public View Container;

        public CustomActorViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            Container = itemView;
            ActorNameTextView = itemView.FindViewById<TextView>(Resource.Id.tv_actor_name);
        }
    }

}