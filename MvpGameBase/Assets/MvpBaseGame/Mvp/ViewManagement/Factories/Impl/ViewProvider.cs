using System.Linq;
using MvpBaseGame.Assets;
using MvpBaseGame.Extensions;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Promises;
using MvpBaseGame.Promises.Impl;
using MvpBaseGame.Utils.PrefabInstantiator;
using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Factories.Impl
{
    public class ViewProvider : IViewProvider
    {
        private readonly IPresenterCreator _presenterCreator;
        private readonly IAssetModel _assetModel;
        private readonly IPrefabInstantiator _instantiator;
        
        public ViewProvider(
            IPresenterCreator presenterCreator,
            IAssetModel assetModel,
            IPrefabInstantiator instantiator)
        {
            _presenterCreator = presenterCreator;
            _assetModel = assetModel;
            _instantiator = instantiator;
        }
    
        public virtual IPromise<IMutableManagedView> Instantiate(IViewData data, Transform transform)
        {
            var outcome = new Promise<IMutableManagedView>();
            var path = GetAssetPath(data.ViewDefinition);

            _assetModel.LoadAsset<GameObject>(path, false)
                .Then(view =>
                {
                    var managedView = CreateInstance(view, transform, data);
                    outcome.Dispatch(managedView);
                })
                .Progress(outcome.ReportProgress)
                .Fail(ex=>
                {
                    Debug.LogError(ex);
                    outcome.ReportFail(ex);
                });

            return outcome;
        }
        
        private IMutableManagedView CreateInstance(GameObject go, Transform transform, IViewData data)
        {
            var instance = _instantiator.Instantiate(go, transform);
        
            IMutableManagedView view;
            var screenBaseView = instance.GetComponent<ScreenBaseView>();
            view = screenBaseView;
        
            instance.GetComponentsInChildren<IView>(true)
                .Where(x => x != view)
                .ForEach(x => _presenterCreator.CreatePresenter(x));
        
            if (screenBaseView != null)
            {
                _presenterCreator.CreatePresenter(screenBaseView, data.Payload);
            }
        
            return view;
        }
        
        private string GetAssetPath(IViewDefinition viewDefinition)
        {
            return viewDefinition.PortraitAssetPath;
        } 

        public void Destroy(IMutableManagedView viewBase)
        {
            viewBase.Current.GetComponentsInChildren<IView>(true)
                .ForEach(_presenterCreator.DestroyPresenter);
            
            Object.Destroy(viewBase.Current);
        }
    }
}
