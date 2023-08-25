using MvpBaseGame.Mvp.ViewManagement.Core.Impl;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public class TaskPopupView : ScreenBaseView, ITaskPopupView
    {
        
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnInteractableChanged(bool isInteractable)
        {
            base.OnInteractableChanged(isInteractable);
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
