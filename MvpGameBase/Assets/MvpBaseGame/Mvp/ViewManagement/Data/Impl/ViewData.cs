namespace MvpBaseGame.Mvp.ViewManagement.Data.Impl
{
    public class ViewData : IViewData
    {
        public IViewListener ViewListener { get; }
        public IViewDefinition ViewDefinition { get; }
        public object Payload { get; }

        public ViewData(IViewDefinition viewDefinition, object payload = null)
        {
            ViewListener = new ViewListener();
            ViewDefinition = viewDefinition;
            Payload = payload;
        }
    }
}
