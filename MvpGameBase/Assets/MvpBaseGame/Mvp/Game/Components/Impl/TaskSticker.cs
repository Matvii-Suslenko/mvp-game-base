using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Components.Impl
{
    public class TaskSticker : MonoBehaviour, ITaskSticker
    {
        public bool IsSeen { get; private set; }

        public void SetIsSeen()
        {
            IsSeen = true;
        }
    }
}
