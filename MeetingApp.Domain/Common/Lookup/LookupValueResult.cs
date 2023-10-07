using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Domain.Common
{
    public class LookupValueResult
    {
        public int id { get; set; }    
        public int status { get; set; }
        public int ordinal { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }   
        public int lookupClassId { get; set; }
        public LookupClassResult lookupClass { get; set; }
    }
}
