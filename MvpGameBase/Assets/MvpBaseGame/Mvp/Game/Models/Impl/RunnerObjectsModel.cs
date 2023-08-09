using MvpBaseGame.Mvp.Game.Data.Impl;
using MvpBaseGame.Mvp.Game.Data;

namespace MvpBaseGame.Mvp.Game.Models.Impl
{
    public class RunnerObjectsModel : IRunnerObjectsModel
    {
        public IUnityObject Pencil => _pencil ??= UnityObject.WithTag("Pencil");
        public IUnityObject Camera => _camera ??= UnityObject.WithTag("MainCamera");
    
        private IUnityObject _pencil;
        private IUnityObject _camera;
    }
}
