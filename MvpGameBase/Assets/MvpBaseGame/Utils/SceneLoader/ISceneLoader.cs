using MvpBaseGame.Promises;

namespace MvpBaseGame.Utils.SceneLoader
{
    public interface ISceneLoader
    {
        IPromise LoadScene(string scenePath, bool isAdditive, bool isAsync);
        
        IPromise UnloadScene(string scenePath);
        
        void AbortSceneLoading(string scenePath);
        
        bool IsSceneLoaded(string scenePath);
    }
}
