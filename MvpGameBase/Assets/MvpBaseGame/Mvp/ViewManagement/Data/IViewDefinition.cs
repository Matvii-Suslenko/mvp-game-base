namespace MvpBaseGame.Mvp.ViewManagement.Data
{
    /// <summary>
    /// Provides the definition of the view configuration.
    /// </summary>
    public interface IViewDefinition
    {
        /// <summary>
        /// Gets the view Id.
        /// </summary>
        string ViewId { get; }
        
        /// <summary>
        /// Gets the layer Id.
        /// </summary>
        string LayerId { get; }
       
        /// <summary>
        /// Gets the path to the assets to be displayed in landscape mode.
        /// </summary>
        string LandscapeAssetPath { get; }
        
        /// <summary>
        /// Gets the path to the assets to be displayed in portrait mode.
        /// </summary>
        string PortraitAssetPath { get; }
        
        /// <summary>
        /// Set true if view shouldn't be added to the history
        /// Can be useful to add some helpers Views, like SpinnerView
        /// </summary>
        bool AddToHistory { get; }

        IViewDefinition Clone(string newLayer);
    }
}
