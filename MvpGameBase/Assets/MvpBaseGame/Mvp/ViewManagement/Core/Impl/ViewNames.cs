using MvpBaseGame.Mvp.ViewManagement.Data.Impl;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public static class ViewNames
    {
        public static readonly IViewDefinition Preloader = new ViewDefinition("PreLoader", LayerNames.Screen, "Assets/AppAssets/Bundles/Common/Prefabs/View_Preloader.prefab");
        public static readonly IViewDefinition Lobby = new ViewDefinition("Lobby", LayerNames.Screen, "Assets/AppAssets/Bundles/Common/Prefabs/View_Lobby.prefab");
        public static readonly IViewDefinition Game = new ViewDefinition("Game", LayerNames.Screen, "Assets/AppAssets/Bundles/Common/Prefabs/View_Game.prefab");
        public static readonly IViewDefinition Paused = new ViewDefinition("Paused", LayerNames.Popup, "Assets/AppAssets/Bundles/Common/Prefabs/View_Paused.prefab");
        public static readonly IViewDefinition Failed = new ViewDefinition("Failed", LayerNames.Popup, "Assets/AppAssets/Bundles/Common/Prefabs/View_Failed.prefab");
        public static readonly IViewDefinition Confirmation = new ViewDefinition("Confirmation", LayerNames.Message, "Assets/AppAssets/Bundles/Common/Prefabs/View_Confirmation.prefab");
    }
}
