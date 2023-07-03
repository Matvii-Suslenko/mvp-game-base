using System;

namespace MvpBaseGame.Bindings
{
    public interface IBindableProperty<out T>
    {
        T Value { get; }
        void Bind(Action listener, bool callImmediately = true);
        void UnBind(Action listener);
        
        void Bind(Action<T> listener, bool callImmediately = true);
        void UnBind(Action<T> listener);
        
        void Bind(Action<T, T> listener, bool callImmediately = true);
        void UnBind(Action<T, T> listener);
    }
}