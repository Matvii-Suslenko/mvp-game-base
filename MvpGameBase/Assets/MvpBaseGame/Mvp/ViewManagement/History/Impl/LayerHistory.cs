using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using System.Collections.Generic;
using System.Linq;

namespace MvpBaseGame.Mvp.ViewManagement.History.Impl
{
    public class LayerHistory : ILayerHistory
    {
        private readonly List<IViewData> _history = new List<IViewData>();

        private IViewData _lastView;
        
        public LayerHistory(IViewLayer layer)
        {
            layer.ViewAdded += OnNewViewAdded;
            layer.AllViewsRemoved += Clear;
        }
        
        public IViewData GetPrevious()
        {
            _history.Remove(_lastView);
            
            var lastView = _history.LastOrDefault();

            if (lastView != null)
            {
                _history.RemoveAt(_history.Count - 1);
            }

            return lastView;
        }

        private void OnNewViewAdded(IViewData openedView)
        {
            _lastView = openedView;
            
            if (openedView.ViewDefinition.AddToHistory)
            {
                _history.Add(openedView);
            }
        }

        public void Clear()
        {
            _history.Clear();
        }
    }
}