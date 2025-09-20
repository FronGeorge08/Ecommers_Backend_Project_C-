using EccomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Database.Database
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string Database {  get; set; }
        public string ConnectionString { get; set; }

    }
}
