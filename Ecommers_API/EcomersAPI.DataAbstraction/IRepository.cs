using EccomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EcomersAPI.DataAbstraction
{
    public interface IRepository<T> where T : IContainsId
    {
         public Task<string> Create(T entity);
         public Task<bool> Update(T entity);
         public Task<bool> Delete(string Id);
         public Task<T>GetById(string Id);
         public Task<List<T>> GetAll();
    }
}
