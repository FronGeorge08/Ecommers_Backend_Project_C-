using EccomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Services
{
    public class ContextProvider : IContextProvider
    {
        Dictionary<string, object> _context=new Dictionary<string, object>();
       
        public object Get(string key)
        {
            if (_context.ContainsKey(key))
                return _context[key];
            return null;
        }

        public void Set(string key, object value)
        {
            _context[key] = value;    
        }
    }
}
