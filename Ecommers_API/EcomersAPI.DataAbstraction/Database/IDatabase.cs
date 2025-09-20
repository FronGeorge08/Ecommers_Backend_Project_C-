using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.DataAbstraction.Database
{
    public interface IDatabase
    {
        public IMongoCollection<T> GetCollection<T>() where T : class;
    }
}
