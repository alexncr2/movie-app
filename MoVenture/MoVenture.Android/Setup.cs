using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using Android.Content;
using MoVenture.Android.Services;
using MvvmCross.Platform;
using MoVenture.Services;
using MoVenture.Interfaces;

namespace MoVenture.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context ctx) : base(ctx)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.RegisterType<INativeValidationService, NativeValidationService>();
            Mvx.RegisterType<IMovieService, MovieService>();

        }
    }
}