using System.Collections.Generic;
using System.Linq;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Factories.Impl
{
    public class ViewLayersFactory : IViewLayersFactory
    {
        private readonly IEnumerable<IViewLayerInfo> _dataSet;
        private readonly IViewProvider _viewProvider;

        public ViewLayersFactory(
            IEnumerable<IViewLayerInfo> dataSet, 
            IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
            _dataSet = dataSet;
        }
        
        public IMutableViewLayer[] Create()
        {
            return _dataSet.Select(l => new ViewLayer(l, _viewProvider)).Cast<IMutableViewLayer>().ToArray();
        }
    }
}