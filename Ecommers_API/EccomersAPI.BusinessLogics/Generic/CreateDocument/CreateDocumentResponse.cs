using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Generic.CreateDocument
{
    public class CreateDocumentResponse
    {
        public HttpStatusCode StatusCode;
        public string Id {  get; set; }
        public string Message {  get; set; }
    }
}
