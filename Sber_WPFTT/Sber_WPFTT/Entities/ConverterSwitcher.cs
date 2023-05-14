using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Sber_WPFTT.Entities
{
    public class ConverterSwitcher<T>
    {
        private Dictionary<T, Binding> _converters = new Dictionary<T, Binding>();
        public ConverterSwitcher() { }
        public bool TryGetConverter(T key, out Binding converter)
        {
            return _converters.TryGetValue(key, out converter);
        }
        public bool TryAddPair(T key, Binding value) 
        {
            if (_converters.ContainsKey(key))
                return false;
            _converters.Add(key, value);
            return true;
        }
    }
}
