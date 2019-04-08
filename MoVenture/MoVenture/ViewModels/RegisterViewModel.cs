using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace MoVenture.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        private string mEmail;
        private string mPassword;
        private string mPassword2;
        private ICommand mRegisterCommand;
        private ICommand mHasAccountCommand;
        private ICoreValidationService mCoreValidationService;
        private INativeValidationService mNativeValidationService;


        public RegisterViewModel(ICoreValidationService cvs, INativeValidationService nvs)
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

        public string SecondPassword
        {
            get { return mPassword2; }
            set { mPassword2 = value; RaisePropertyChanged(() => SecondPassword); }
        }

        public ICommand RegisterCommand
        {
            get
            {
                if (mRegisterCommand == null)
                {
                    mRegisterCommand = new MvxCommand(DecideIfActive);
                }
                return mRegisterCommand;
            }
        }

        public ICommand HasAccountCommand
        {
            get
            {
                if (mHasAccountCommand == null)
                {
                    mHasAccountCommand = new MvxCommand(SwitchAuthMode);
                }
                return mHasAccountCommand;
            }
        }

        private void DecideIfActive()
        {
            if (mCoreValidationService.IsRegisterValid(mEmail, mPassword, mPassword2))
            {
                ShowViewModel<MoviesViewModel>();
                return;
            }
            mNativeValidationService.ShowNativeMessage("Register attempt invalid");
        }

        private void SwitchAuthMode()
        {
            ShowViewModel<LoginViewModel>();
        }
    }
}
