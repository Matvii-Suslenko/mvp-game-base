using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Data
{
    /// <summary>
    /// Transformation and configuration data for a layer.
    /// </summary>
    public interface IViewLayerInfo
    {
        /// <summary>
        /// Layer transform.
        /// </summary>
        Transform LayerTransform { get; set; }
        
        /// <summary>
        /// Checks if 'focus is ignored' flag set for the layer.
        /// </summary>
        bool IsFocusIgnored { get; }

        /// <summary>
        /// Layer Id.
        /// </summary>
        string LayerId { get; }
        
    }
}