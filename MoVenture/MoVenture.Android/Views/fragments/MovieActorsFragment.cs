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
using System;
using System.Collections.Generic;
using System.Linq;

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

            ActorsRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity, RecyclerView.Vertical, false));
            ActorsRecyclerView.Adapter = new CustomActorAdapter((IMvxAndroidBindingContext)BindingContext, this.ViewModel.Actors, OnRowClicked);

            return rootView;
        }

        public void OnRowClicked(int row)
        {
            var actor = ViewModel.Actors[row];
        }
    }

    public class CustomActorAdapter : MvxRecyclerAdapter
    {
        private readonly List<Actor> allActors;
        public Action<int> OnRowClicked { get; set; }

        public CustomActorAdapter(IMvxAndroidBindingContext bindingContext, IEnumerable<Actor> a, Action<int> onRowClicked) : base(bindingContext)
        {
            this.allActors = a.ToList();
            OnRowClicked = onRowClicked;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            base.OnCreateViewHolder(parent, viewType);

            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new CustomActorViewHolder(view, itemBindingContext)
            {
                Click = ItemClick
            };
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            var castedHolder = holder as CustomActorViewHolder;
            if (castedHolder == null)
            {
                return;
            }

            castedHolder.ActorImageView.ClipToOutline = true;

            var a = allActors[position];

            castedHolder.Container.Tag = position;
            try
            {
                castedHolder.Container.Click -= Container_Click;
            }
            catch (Exception e)
            {
            }
            castedHolder.Container.Click += Container_Click;
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


    public class CustomActorViewHolder : MvxRecyclerViewHolder
    {
        public ImageView ActorImageView;
        public View Container;

        public CustomActorViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            Container = itemView;
            ActorImageView = itemView.FindViewById<ImageView>(Resource.Id.iv_actor_image);
        }
    }

}