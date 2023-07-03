using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.History
{
    public interface ILayerHistory
    {
        IViewData GetPrevious();
        void Clear();
    }
}