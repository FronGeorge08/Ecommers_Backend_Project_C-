using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EccomersAPI.DataAbstraction.Extensions
{
    public static class StringExtension
    {
        public static bool IsValidId(this string ID)
        {
            if (ID == null)
                return false;
            if (ObjectId.TryParse(ID, out var Id) == true)
                return true;
            else
                return false;
        }
    }
}
