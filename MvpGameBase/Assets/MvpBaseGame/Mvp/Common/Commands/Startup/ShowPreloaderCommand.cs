using MvpBaseGame.Commands.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;

namespace MvpBaseGame.Mvp.Common.Commands.Startup
{
    public class ShowPreloaderCommand: AsyncCommand
    {
        private readonly IViewManager _viewManager;

        public ShowPreloaderCommand(IViewManager viewManager)
        {
            _viewManager = viewManager;
        }
        
        protected override void Execute()
        {
            _viewManager.OpenView(ViewNames.Preloader).ViewOpened.Then(Release);
        }
    }
}