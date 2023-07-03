using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using System.Collections.Generic;
using System.Linq;

namespace MvpBaseGame.Mvp.ViewManagement.Factories.Impl
{
    public class DefaultCreateViewStrategy : ICreateViewStrategy
    {
        public IViewListener CreateView(IViewData viewData, IMutableViewLayer[] layers)
        {
            var currentLayer = layers.FirstOrDefault(layer => viewData.ViewDefinition.LayerId == layer.LayerInfo.LayerId);
            if (currentLayer == null)
            {
                throw new KeyNotFoundException($"Layer {viewData.ViewDefinition.LayerId} not found!");
            }
            
            currentLayer.CreateView(viewData);
            return viewData.ViewListener;
        }
    }
}
