using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class ValueChangeArgs<T> : EventArgs
    {
        public T Value { get; }

        public ValueChangeArgs(T value)
        {
            Value = value;
        }
    }
}
