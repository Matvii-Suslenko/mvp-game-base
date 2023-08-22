using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    public interface IScreenBaseView : IManagedView, IView
    {
        /// <summary>
        /// Fires on Android Device Back Button Click
        /// </summary>
        event Action DeviceBackClicked;
        
        /// <summary>
        /// Fires on Focus Change
        /// </summary>
        event Action<bool> FocusChanged;
        
        /// <summary>
        /// Determines whether the view has focus or not.
        /// </summary>
        bool HasFocus { get; }
    }
}
