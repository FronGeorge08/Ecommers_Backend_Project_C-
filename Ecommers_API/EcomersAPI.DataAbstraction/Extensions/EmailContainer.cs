using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.DataAbstraction.Extensions
{
    public static class EmailContainer
    {
        public static bool EmailCheck(this string Email)
        {
            List<string> list = ["gmail.com","yahoo.com"];
            string[] strings = Email.Split("@");
            if (list.Contains(strings[1]))
                return true;
            return false;
        }
    }
}
