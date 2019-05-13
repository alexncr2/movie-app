
using Android.App;
using MoVenture.ViewModels;

namespace MoVenture.Android.Views
{
    [Activity(MainLauncher = true, Theme = "@style/MainTheme.Base")]
    public class LoginActivity : BaseActivity
    {
        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.activity_login);

            ViewModel.Email = "test_user@test.com";
            ViewModel.Password = "hunter2";
        }
    }
}