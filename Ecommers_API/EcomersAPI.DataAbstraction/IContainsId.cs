using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.DataAbstraction
{
    public interface IContainsId
    {
        public string Id { get; set; }
    }
}
