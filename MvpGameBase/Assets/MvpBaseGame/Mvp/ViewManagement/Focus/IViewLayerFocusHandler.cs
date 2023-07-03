using System;
using System.Collections.Generic;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Focus
{
    public interface IViewLayerFocusHandler
    {
        event Action<IViewLayerInfo> FocusRefreshed;
        void SetLayers(IEnumerable<IMutableViewLayer> layers);
    }
}
