using MvpBaseGame.Mvp.ViewManagement.Core;

namespace MvpBaseGame.Mvp.ViewManagement.Factories
{
    public interface IViewLayersFactory
    {
        IMutableViewLayer[] Create();
    }
}