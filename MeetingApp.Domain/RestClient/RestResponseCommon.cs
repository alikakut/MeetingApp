using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Domain.RestClient
{
    public class RestResponseCommon
    {
        public HttpStatusCode? HttpStatusCode { get; set; }
        public List<RestHeader> Headers { get; set; }
    }
}
