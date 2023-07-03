using System.Collections.Generic;
using DG.Tweening;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.Overlay;
using UnityEngine;
using UnityEngine.UI;

namespace ProductMadness.CashmanCasino.Mvp.Views.Overlay
{
    [RequireComponent(typeof(Canvas))]
    public class BlurOverlayView : MonoBehaviour, IBlurOverlayView
    {
        [SerializeField]
        protected Image _blackoutImage;

        [SerializeField]
        protected float _fadeDuration = 0.3f;

        private float _defaultAlpha;
        private bool _isHidden = true;

        private RectTransform _rectTransform;
        private Canvas _canvas;

        private readonly Dictionary<string, Canvas> _layerCanvases = new Dictionary<string, Canvas>();

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _rectTransform = transform as RectTransform;
            _canvas.enabled = true;
            
            _blackoutImage.gameObject.SetActive(false);
            var color = _blackoutImage.color;
            _defaultAlpha = color.a;
            color.a = 0;
            _blackoutImage.color = color;
        }

        public void SetLayers(IEnumerable<IViewLayerInfo> layersConfiguration)
        {
            foreach (var layerInfo in layersConfiguration)
            {
                _layerCanvases.Add(layerInfo.LayerId, layerInfo.LayerTransform.GetComponent<Canvas>());
            }
        }

        public void Show(string layerId, float? customAlpha, float? customFadeDuration)
        {
            var alpha = customAlpha ?? _defaultAlpha;
            var duration = customFadeDuration ?? _fadeDuration;
            Show(alpha, duration);
            RefreshOrder(layerId);
        }

        private void Show(float alpha, float duration)
        {
            if (!_isHidden)
            {
                return;
            }

            _isHidden = false;
            _blackoutImage.DOKill();
            _blackoutImage.gameObject.SetActive(true);
            _blackoutImage.DOFade(alpha, duration);
        }

        public void Hide(bool immediate = false)
        {
            if (_isHidden)
            {
                return;
            }

            _isHidden = true;

            if (immediate)
            {
                OnFadeOutComplete();
            }
            else
            {
                _blackoutImage.DOKill();
                _blackoutImage.DOFade(0, _fadeDuration).OnComplete(OnFadeOutComplete);
            }
        }

        private void OnFadeOutComplete()
        {
            _blackoutImage.gameObject.SetActive(false);
        }

        public void RefreshOrder(string layerId)
        {
            if (_layerCanvases.TryGetValue(layerId, out var layerCanvas))
            {
                _canvas.sortingLayerName = layerId;
                _rectTransform.position = layerCanvas.transform.position;
                _canvas.sortingOrder = layerCanvas.sortingOrder - 1;
                LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
            }
        }
    }
}