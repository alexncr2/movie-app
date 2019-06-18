using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Java.Lang;
using MoVenture.Android.Views.fragments;
using MoVenture.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using Newtonsoft.Json;

namespace MoVenture.Android
{
    public class MvxFragmentPagerAdapter : FragmentPagerAdapter
    {
        private readonly Context _context;
        private readonly Movie movie;

        protected MvxFragmentPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        // add movieid param
        public MvxFragmentPagerAdapter(Context context, FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments, Movie mv)
            : base(fragmentManager)
        {
            _context = context;
            Fragments = fragments;
            this.movie = mv;
        }

        public IEnumerable<FragmentInfo> Fragments { get; private set; }

        public override int Count
        {
            get { return Fragments.Count(); }
        }

        public override Fragment GetItem(int position)
        {
            FragmentInfo fragInfo = Fragments.ElementAt(position);

            if (fragInfo.CachedFragment == null)
            {
                fragInfo.CachedFragment = Fragment.Instantiate(_context, FragmentJavaName(fragInfo.FragmentType));
                
                var param = new Dictionary<string, string>
                {
                    { "movie", JsonConvert.SerializeObject(movie) }
                };
                var bundle = new MvxBundle(param);

                var request = new MvxViewModelRequest(fragInfo.ViewModelType, bundle, null);
                try
                {
                    ((IMvxView)fragInfo.CachedFragment).ViewModel = Mvx.Resolve<IMvxViewModelLoader>().LoadViewModel(request, null);
                }
                catch(System.Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("MvxFragmentPagerAdapter? " + e.ToString());
                }
            }

            return fragInfo.CachedFragment;
        }

        protected static string FragmentJavaName(Type fragmentType)
        {
            string namespaceText = fragmentType.Namespace ?? "";
            if (namespaceText.Length > 0)
                namespaceText = namespaceText.ToLowerInvariant() + ".";
            return namespaceText + fragmentType.Name;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(Fragments.ElementAt(position).Title);
        }

        public override void RestoreState(IParcelable state, ClassLoader loader)
        {
            //Don't call restore to prevent crash on rotation
            //base.RestoreState (state, loader);
        }

        public class FragmentInfo
        {
            public FragmentInfo(string title, Type fragmentType, Type viewModelType)
            {
                Title = title;
                FragmentType = fragmentType;
                ViewModelType = viewModelType;
            }

            public string Title { get; set; }
            public Type FragmentType { get; private set; }
            public Type ViewModelType { get; private set; }
            public Fragment CachedFragment { get; set; }
        }
    }
}
