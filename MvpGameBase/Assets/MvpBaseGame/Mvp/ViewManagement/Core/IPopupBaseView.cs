using System;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    public interface IPopupBaseView : IScreenBaseView
    {
         event Action CloseClicked;
    }
}