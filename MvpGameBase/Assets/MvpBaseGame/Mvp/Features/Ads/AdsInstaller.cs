using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Mvp.Common.Installers;
using MvpBaseGame.Commands.Core;

namespace MvpBaseGame.Mvp.Features.Ads
{
    public class AdsInstaller : MvpInstaller
    {
        public AdsInstaller(
            IPresenterBinder presenterBinder,
            ICommandBinder commandBinder) : base(presenterBinder, commandBinder)
        {
        }

        protected override void BindCommon()
        {
            
        }

        protected override void BindModels()
        {
        }

        protected override void BindServices()
        {
        }
        
        protected override void BindPresenters(IPresenterBinder presenterBinder)
        {
        }

        protected override void BindCommands(ICommandBinder commandBinder)
        {
        }
    }
}