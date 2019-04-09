
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MoVenture.Models;
using MoVenture.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using System.Collections.Generic;
using System.Linq;

namespace MoVenture.Android.Views
{
    [Activity]
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

            var ActorsRecyclerView = FindViewById<MvxRecyclerView>(Resource.Id.rv_actors_list);
            ActorsRecyclerView.SetLayoutManager(new LinearLayoutManager(this, RecyclerView.Horizontal, false));
            ActorsRecyclerView.Adapter = new CustomActorAdapter((IMvxAndroidBindingContext)BindingContext, ViewModel.Movie);

            var CommentsRecyclerView = FindViewById<MvxRecyclerView>(Resource.Id.rv_comments_list);
            CommentsRecyclerView.SetLayoutManager(new LinearLayoutManager(this, RecyclerView.Vertical, false));
            CommentsRecyclerView.Adapter = new CustomCommentAdapter((IMvxAndroidBindingContext)BindingContext, ViewModel.Movie);
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






    public class CustomCommentAdapter : MvxRecyclerAdapter
    {
        private readonly Movie Movie;

        public CustomCommentAdapter(IMvxAndroidBindingContext bindingContext, Movie movie) : base(bindingContext)
        {
            this.Movie = movie;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            base.OnCreateViewHolder(parent, viewType);

            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new CustomCommentViewHolder(view, itemBindingContext);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            var castedHolder = holder as CustomCommentViewHolder;
            if (castedHolder == null)
            {
                return;
            }


        }
    }


    public class CustomCommentViewHolder : MvxRecyclerViewHolder
    {
        public TextView CommentMessageTextView;
        public View Container;

        public CustomCommentViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            Container = itemView;
            CommentMessageTextView = itemView.FindViewById<TextView>(Resource.Id.tv_comment_msg);
        }
    }

}
