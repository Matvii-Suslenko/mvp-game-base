using MvpBaseGame.Mvp.Game.Data;
using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Models.Impl
{
    public class RunnerObjectsModel : IRunnerObjectsModel
    {
        public IPencilObject Pencil => _pencil ??= GameObject.FindWithTag("Pencil").GetComponent<IPencilObject>();
    
        private IPencilObject _pencil;
    }
}
