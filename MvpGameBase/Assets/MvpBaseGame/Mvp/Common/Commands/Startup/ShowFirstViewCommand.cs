using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Commands.Core.Impl;

namespace MvpBaseGame.Mvp.Common.Commands.Startup
{
    public class ShowFirstViewCommand : AsyncCommand
    {
        private readonly IViewManager _viewManager;

        public ShowFirstViewCommand(IViewManager viewManager)
        {
            _viewManager = viewManager;
        }
        
        protected override void Execute()
        {
            _viewManager.OpenView(ViewNames.Lobby).ViewOpened.Then(Release);
        }
    }
}
