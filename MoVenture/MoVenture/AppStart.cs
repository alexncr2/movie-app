using MvvmCross.Core.ViewModels;
using MoVenture.ViewModels;

namespace MoVenture
{
    class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            ShowViewModel<LoginViewModel>();
        }
    }
}
