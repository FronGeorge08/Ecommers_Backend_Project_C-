using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.CommonDomain.Users
{
    public class GetUserByIdDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email {  get; set; }
        public string Name { get; set; }
    }
}
