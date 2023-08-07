namespace MvpBaseGame.Mvp.ViewManagement.Animation
{
    public interface IAnimationCallbackReceiver<TTriggers>
    {
        void AnimationEventCallBack(TTriggers trigger);
    }
}