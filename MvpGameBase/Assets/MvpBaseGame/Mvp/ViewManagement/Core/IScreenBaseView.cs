using System;
using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    public interface IScreenBaseView : IManagedView, IView
    {
        event Action DeviceBackClicked;
        
        event Action<bool> FocusChanged;
        
        /// <summary>
        /// Determines whether the view has focus or not.
        /// </summary>
        bool HasFocus { get; }
    }
}