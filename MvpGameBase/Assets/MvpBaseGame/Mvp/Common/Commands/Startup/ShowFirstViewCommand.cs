using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Utils.SceneLoader.Impl;
using MvpBaseGame.Commands.Core.Impl;
using MvpBaseGame.Utils.SceneLoader;
using System;

namespace MvpBaseGame.Mvp.Common.Commands.Startup
{
    public class ShowFirstViewCommand : AsyncCommand
    {
        private readonly IViewManager _viewManager;
        private readonly ISceneLoader _sceneLoader;

        public ShowFirstViewCommand(IViewManager viewManager, ISceneLoader sceneLoader)
        {
            _viewManager = viewManager;
            _sceneLoader = sceneLoader;
        }
        
        protected override void Execute()
        {
            var promise = _sceneLoader.LoadScene(Scenes.ThreeDimensionalScene, true, true);
            promise.Then(OnLobbySceneLoaded);
            promise.Fail(OnLoadFailed);
        }

        private void OnLoadFailed(Exception obj)
        {
            throw new NotImplementedException();
        }

        private void OnLobbySceneLoaded()
        {
            _viewManager.OpenView(ViewNames.Lobby).ViewOpened.Then(Release);
        }
    }
}
