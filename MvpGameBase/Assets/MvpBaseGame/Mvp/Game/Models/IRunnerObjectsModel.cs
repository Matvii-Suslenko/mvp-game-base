using MvpBaseGame.Mvp.Game.Data;

namespace MvpBaseGame.Mvp.Game.Models
{
    public interface IRunnerObjectsModel
    {
        /// <summary>
        /// Pencil Object
        /// </summary>
        IUnityObject Pencil { get; }
        
        /// <summary>
        /// Camera Object
        /// </summary>
        IUnityObject Camera { get; }
    }
}
