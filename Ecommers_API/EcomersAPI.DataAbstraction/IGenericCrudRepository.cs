using EcomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.DataAbstraction
{
    public interface IGenericCrudRepository<T>:IRepository<T>
    where T : IContainsId
    {

    }
}
