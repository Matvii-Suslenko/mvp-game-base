namespace MvpBaseGame.Commands.Core
{
    public interface ICommandBinder
    {
        ICommandBinding<TContract> Bind<TContract>();
        
        ICommandBinding<TContract> ReBind<TContract>();
        
        ICommandBinding<TContract> GetBind<TContract>();
        
        void UnBind<TContract>();
    }
}
