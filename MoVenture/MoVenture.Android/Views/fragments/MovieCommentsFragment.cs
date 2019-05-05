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
using System.Collections.Generic;
using System.Linq;

namespace MoVenture.Android.Views.fragments
{
    [Register("moventure.android.views.fragments.MovieCommentsFragment")]
    public class MovieCommentsFragment : MvxFragment<MovieCommentsViewModel>
    {
        public MovieCommentsFragment()
        {

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                  Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var rootView = this.BindingInflate(Resource.Layout.fragment_movie_comments, null);

            var CommentsRecyclerView = rootView.FindViewById<MvxRecyclerView>(Resource.Id.rv_comments_list);

            CommentsRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity, RecyclerView.Vertical, false));
            CommentsRecyclerView.Adapter = new CustomCommentAdapter((IMvxAndroidBindingContext)BindingContext, this.ViewModel.Comments);

            return rootView;
        }
    }


    public class CustomCommentAdapter : MvxRecyclerAdapter
    {
        private readonly List<Comment> allComments;

        public CustomCommentAdapter(IMvxAndroidBindingContext bindingContext, IEnumerable<Comment> c) : base(bindingContext)
        {
            allComments = c.ToList();
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