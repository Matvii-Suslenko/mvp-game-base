using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.History
{
    public interface IViewManagerHistory
    {
        IViewListener OpenPreviousView();
        
        IViewListener OpenPreviousView(IManagedView view);
        
        void ClearHistoryLayer(string layerId);
    }
}