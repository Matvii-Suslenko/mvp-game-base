using System;

namespace MvpBaseGame.Bindings.Impl
{
    public class BindableProperty<T> : IMutableBindableProperty<T>
    {
        private Action _onChange;
        private Action<T> _onChange1;
        private Action<T, T> _onChange2;

        private bool _isRetained;
        private T _retainedValue;
        private T _value;
        private T _oldValue;

        public BindableProperty()
        {
        }
        
        public BindableProperty(T value)
        {
            _oldValue = value;
            _value = value;
        }
        
        public T Value
        {
            get => _value;
            set
            {
                if (_value != null && !_value.Equals(value) || _value == null && value != null)
                {
                    if (!_isRetained)
                    {
                        _oldValue = _value;
                    }
                  
                    _value = value;
                    
                    if (!_isRetained)
                    {
                        ExecuteBinding(_value);
                    }
                }
            }
        }

        public void Bind(Action listener, bool callImmediately = true)
        {
            _onChange += listener;

            if (callImmediately)
            {
                listener?.Invoke();
            }
        }

        public void UnBind(Action listener)
        {
            _onChange -= listener;
        }
        
        public void Bind(Action<T> listener, bool callImmediately = true)
        {
            _onChange1 += listener;

            if (callImmediately)
            {
                listener.Invoke(_isRetained ? _retainedValue : Value);
            }
        }

        public void UnBind(Action<T> listener)
        {
            _onChange1 -= listener;
        }
        
        public void Bind(Action<T, T> listener, bool callImmediately = true)
        {
            _onChange2 += listener;
            
            if (callImmediately)
            {
                listener.Invoke(_isRetained ? _retainedValue : Value, _oldValue);
            }
        }

        public void UnBind(Action<T,T> listener)
        {
            _onChange2 -= listener;
        }
        
        private void ExecuteBinding(T newValue)
        {
            _onChange?.Invoke();
            _onChange1?.Invoke(newValue);
            _onChange2?.Invoke(newValue, _oldValue);
        }

        public void UnBindAll()
        {
            _onChange = null;
            _onChange1 = null;
            _onChange2 = null;
        }

        public void Retain()
        {
            _isRetained = true;
            _retainedValue = Value;
        }

        public void Release()
        {
            if (_isRetained)
            {
                _isRetained = false;
                if (!_value.Equals(_retainedValue))
                {
                    ExecuteBinding(_value);
                }
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}