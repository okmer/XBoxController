using System;

using Com.Okmer.GameController.Helpers;

namespace Com.Okmer.GameController
{
    public abstract class XBoxComponent<T> : NotifyPropertyChanged
    {
        public event EventHandler<ValueChangeArgs<T>> ValueChanged;

        private T previousValue;
        public T PreviousValue
        {
            get => previousValue;
            private set
            {
                if (!previousValue.Equals(value))
                {
                    previousValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private T value;
        public virtual T Value
        {
            get => value;
            internal set
            {
                PreviousValue = Value;
                if (!Value.Equals(value))
                {
                    this.value = value;
                    OnPropertyChanged();
                    OnValueChanged(new ValueChangeArgs<T>(Value));
                }
            }
        }

        public bool IsValueChanged

        {
            get => !Value.Equals(PreviousValue);
        }

        public XBoxComponent(T initialValue)
        {
            value = initialValue;
        }

        protected virtual void OnValueChanged(ValueChangeArgs<T> e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
