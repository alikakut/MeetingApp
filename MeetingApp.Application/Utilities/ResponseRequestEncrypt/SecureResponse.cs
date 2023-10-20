using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Extensions;

namespace MeetingApp.Application.Utilities.ResponseRequestEncrypt
{
    public class SecureResponse
    {
        public SecureResponse()
        {

        }
        public SecureResponse(object @object)
        {
           // Response = AES.EncryptStringAES(@object.ToJSON());
        }
        public string Response { get; set; }
    }
}
