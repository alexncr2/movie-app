using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform;
using MoVenture.Services;
using MoVenture.Interfaces;

namespace MoVenture
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();

            Mvx.RegisterType<ICoreValidationService, CoreValidationService>();

            RegisterAppStart(Mvx.Resolve<IMvxAppStart>());
        }
    }
}
