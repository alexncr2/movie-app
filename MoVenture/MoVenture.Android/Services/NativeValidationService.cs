
using Android.Widget;
using MoVenture.Android.Application;

namespace MoVenture.Android.Services
{
    class NativeValidationService : INativeValidationService
    {
        public void ShowNativeMessage(string message)
        {
            // Console.WriteLine(message);
            var instance = CustomApplication.Instance;
            var activity = instance.CurrentActivity;
            Toast.MakeText(activity, message, ToastLength.Short).Show();
        }
    }
}