using MoVenture.ViewModels;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private string mEmail;
        private string mPassword;
        private ICommand mLoginCommand;
        private ICommand mCreateAccountCommand;
        private ICommand mForgotPasswordCommand;
        private ICoreValidationService mCoreValidationService;
        private INativeValidationService mNativeValidationService;

        public LoginViewModel(ICoreValidationService cvs, INativeValidationService nvs)
        {
            mCoreValidationService = cvs;
            mNativeValidationService = nvs;
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; RaisePropertyChanged(() => Email); }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; RaisePropertyChanged(() => Password); }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (mLoginCommand == null)
                {
                    mLoginCommand = new MvxCommand(DecideIfActive);
                }
                return mLoginCommand;
            }
        }

        public ICommand CreateAccountCommand
        {
            get
            {
                if (mCreateAccountCommand == null)
                {
                    mCreateAccountCommand = new MvxCommand(SwitchAuthMode);
                }
                return mCreateAccountCommand;
            }
        }

        public ICommand ForgotPasswordCommand
        {
            get
            {
                if (mForgotPasswordCommand == null)
                {
                    mForgotPasswordCommand = new MvxCommand(ForgotPassword);
                }
                return mForgotPasswordCommand;
            }
        }

        private void DecideIfActive()
        {
            if (mCoreValidationService.IsLoginValid(mEmail, mPassword))
            {
                ShowViewModel<MoviesViewModel>();
                return;
            }
            mNativeValidationService.ShowNativeMessage("Login attempt invalid");
        }

        private void SwitchAuthMode()
        {
            ShowViewModel<RegisterViewModel>();
        }

        private void ForgotPassword()
        {

        }

    }
}
