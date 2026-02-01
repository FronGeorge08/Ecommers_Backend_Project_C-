using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.DataAbstraction
{
    public interface IContextProvider
    {
        public void Set(string key, object value);
        public object Get(string key);
    }
}
