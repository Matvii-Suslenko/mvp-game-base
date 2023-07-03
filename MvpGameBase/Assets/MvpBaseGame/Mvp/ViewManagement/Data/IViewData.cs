namespace MvpBaseGame.Mvp.ViewManagement.Data
{
    /// <summary>
    /// View configuration and listener data.
    /// </summary>
    public interface IViewData
    {
        /// <summary>
        /// Gets configuration of the view 
        /// </summary>
        IViewDefinition ViewDefinition { get; }
        
        /// <summary>
        /// Gets signals on the opening and closing of the view.
        /// </summary>
        IViewListener ViewListener { get; }
        
        /// <summary>
        /// Payload passed to the view
        /// </summary>
        object Payload { get; }
    }
}
