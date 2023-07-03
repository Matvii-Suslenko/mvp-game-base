using System.Collections.Generic;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.History
{
    public interface IViewLayerHistoryHandler
    {
        void SetLayers(IEnumerable<IViewLayer> layers);
        IViewData GetPrevious(IViewDefinition view);
        void Clear(string layerId);
    }
}
