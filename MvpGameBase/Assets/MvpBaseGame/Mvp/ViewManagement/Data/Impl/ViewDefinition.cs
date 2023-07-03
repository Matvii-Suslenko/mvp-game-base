namespace MvpBaseGame.Mvp.ViewManagement.Data.Impl
{
    public class ViewDefinition : IViewDefinition
    {
        public string ViewId { get; private set; }
        public string LayerId { get; private set;}
        public string LandscapeAssetPath { get; private set; }
        public string PortraitAssetPath { get; private set;}
        public bool AddToHistory { get; private set; }

        private ViewDefinition()
        {

        }

        public ViewDefinition(string viewName, string layerId, string assetPath, bool useTwoOrientations = false, bool addToHistory = false)
        {
            ViewId = viewName;
            LayerId = layerId;
            if (useTwoOrientations)
            {
                LandscapeAssetPath = assetPath + "_Landscape";
                PortraitAssetPath = assetPath + "_Portrait";
            }
            else
            {
                LandscapeAssetPath = assetPath;
                PortraitAssetPath = assetPath;
            }
            AddToHistory = addToHistory;
        }

        public override string ToString()
        {
            return ViewId;
        }
        
        public IViewDefinition Clone(string newLayer)
        {
            var newViewDef = new ViewDefinition
            {
                ViewId = ViewId,
                LayerId = newLayer,
                LandscapeAssetPath = LandscapeAssetPath,
                PortraitAssetPath = PortraitAssetPath,
                AddToHistory = AddToHistory
            };
            return newViewDef;
        }
    }
}
