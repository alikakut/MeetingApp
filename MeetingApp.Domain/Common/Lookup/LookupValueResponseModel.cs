using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.RestClient;

namespace MeetingApp.Domain.Common
{
    public class LookupValueResponseModel : RestResponseCommon
    {
        public object messages { get; set; }
        public bool successful { get; set; }
        public List<LookupValueResult> result { get; set; }
    }
}
