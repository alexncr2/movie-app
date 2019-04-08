
using Android.App;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(Label = "Login", MainLauncher = true)]
    public class LoginActivity : BaseActivity
    {
        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_login);
        }
    }
}