using UnityEngine.Serialization;
using UnityEngine;

namespace ProductMadness.CashmanCasino.Mvp.Views.Overlay
{
    public class AutoBlurOverlay : MonoBehaviour
    {
        [FormerlySerializedAs("OverridesFadeTime")]
        [SerializeField] 
        private bool _overridesFadeTime;
        
        [FormerlySerializedAs("OverridesAlpha")]
        [SerializeField] 
        private bool _overridesAlpha;

        [FormerlySerializedAs("CustomFadeDuration")]
        [SerializeField] 
        private float _customFadeDuration = 0.1f;
        
        [FormerlySerializedAs("CustomAlpha")]
        [SerializeField] 
        [Range(0.5f,1f)]
        private float _customAlpha = 0.9f;

        public float? CustomAlpha
        {
            get
            {
                if (_overridesAlpha)
                {
                    return _customAlpha;
                }

                return null;
            }
        }
        
        public float? CustomFadeDuration
        {
            get
            {
                if (_overridesFadeTime)
                {
                    return _customFadeDuration;
                }

                return null;
            }
        }
    }
}
