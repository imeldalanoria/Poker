using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Library.Conversion
{
    public interface IConverter<T>
    {
        string ToString(T value);

        T FromString(string str);
    }
}
