using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Data.Impl
{
    [Serializable]
    public class ViewLayerInfo : IViewLayerInfo
    {
        [SerializeField]
        private Transform _layerTransform;
        
        [SerializeField]
        private bool _isFocusIgnored;

        private string _layerId;
        
        public Transform LayerTransform
        {
            get => _layerTransform;
            set => _layerTransform = value;
        }

        public bool IsFocusIgnored => _isFocusIgnored;

        public string LayerId => _layerTransform == null ? _layerId : _layerTransform.name;

        public ViewLayerInfo(string layerId, bool isFocusIgnored)
        {
            _layerId = layerId;
            _isFocusIgnored = isFocusIgnored;
        }
    }
}