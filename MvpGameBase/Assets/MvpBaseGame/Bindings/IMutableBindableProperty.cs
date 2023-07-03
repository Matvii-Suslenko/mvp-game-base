namespace MvpBaseGame.Bindings
{
    public interface IMutableBindableProperty<T> : IBindableProperty<T>
    {
        new T Value { get; set; }
        void UnBindAll();
        void Retain();
        void Release();
    }
}