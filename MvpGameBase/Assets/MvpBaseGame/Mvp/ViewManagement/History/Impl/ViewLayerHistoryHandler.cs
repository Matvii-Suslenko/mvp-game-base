using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using System.Collections.Generic;

namespace MvpBaseGame.Mvp.ViewManagement.History.Impl
{
    public class ViewLayerHistoryHandler : IViewLayerHistoryHandler
    {
        private readonly Dictionary<string, ILayerHistory> _layers = new Dictionary<string, ILayerHistory>();

        public void SetLayers(IEnumerable<IViewLayer> layers)
        {
            foreach (var layer in layers)
            {
                _layers.Add(layer.LayerInfo.LayerId, new LayerHistory(layer));
            }
        }

        public IViewData GetPrevious(IViewDefinition viewDef)
        {
            return _layers[viewDef.LayerId].GetPrevious();
        }

        public void Clear(string layerId)
        {
            _layers[layerId].Clear();
        }
    }
}