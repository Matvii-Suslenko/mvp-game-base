using MvpBaseGame.Mvp.ViewManagement.Data.Impl;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public static class ViewNames
    {
        public static readonly IViewDefinition Preloader = new ViewDefinition("PreLoader", LayerNames.Screen, "Assets/MvpBaseGame/Prefabs/View_Preloader.prefab");
        public static readonly IViewDefinition Lobby = new ViewDefinition("Lobby", LayerNames.Screen, "Assets/MvpBaseGame/Prefabs/View_Lobby.prefab");
    }
}
