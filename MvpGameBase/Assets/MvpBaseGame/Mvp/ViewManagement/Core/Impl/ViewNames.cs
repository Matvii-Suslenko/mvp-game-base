using MvpBaseGame.Mvp.ViewManagement.Data.Impl;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public static class ViewNames
    {
        public static readonly IViewDefinition Preloader = new ViewDefinition("PreLoader", LayerNames.Screen, "Common/Prefabs/View_Preloader");
        public static readonly IViewDefinition Lobby = new ViewDefinition("Lobby", LayerNames.Screen, "Common/Prefabs/View_Lobby");
        public static readonly IViewDefinition Game = new ViewDefinition("Game", LayerNames.Screen, "Common/Prefabs/View_Game");
        public static readonly IViewDefinition Paused = new ViewDefinition("Paused", LayerNames.Popup, "Common/Prefabs/View_Paused");
        public static readonly IViewDefinition Failed = new ViewDefinition("Failed", LayerNames.Popup, "Common/Prefabs/View_Failed");
        public static readonly IViewDefinition Task = new ViewDefinition("Task", LayerNames.Popup, "Common/Prefabs/View_Task");
        public static readonly IViewDefinition Confirmation = new ViewDefinition("Confirmation", LayerNames.Message, "Common/Prefabs/View_Confirmation");
    }
}
